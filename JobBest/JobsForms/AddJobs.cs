using Guna.UI2.WinForms;
using JobBest.Classes;
using JobBest.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.JobsForms
{
    public partial class AddJobs : Form
    {
        private bool edited;
        private string idJob = null;
        private string idVacancy = null;


        AppPage.OpenForm of;
        private int pictureNumber = 0;
        private bool isOrder = false;
        private string format= "В офисе";
        private string timetable= "Полный день";
        private string special= "Оклад";
        private Image[] imageArray = new Image[5]; 
        private Guna2PictureBox[] pictureArray = new Guna2PictureBox[5];
        private int selectedImage;
        private string changeCountry = null;

        private string changeCategory = null;


        private void openImageForm(object sender, EventArgs e)
        {
            viewImagePanel.Visible = true;
            Guna2PictureBox pictureBox = (Guna2PictureBox)sender;
            imagePanel.Image = pictureBox.Image;
            selectedImage = int.Parse(pictureBox.Tag.ToString()[1].ToString());
            if (pictureNumber-1==0)
            {
                iconPictureBox3.Visible = false;
                iconPictureBox2.Visible = false;
            }
            else
            {
                iconPictureBox3.Visible = true;
                iconPictureBox2.Visible = true;
            }
        }

        public AddJobs(AppPage.OpenForm OpenChildForm, bool edits, string idJob)
        {
            InitializeComponent();
            dateFinishTime.Value = DateTime.Now;
            of = OpenChildForm;
            viewImagePanel.Location = new Point(176, 128);
            CountryComboBox.DataSource = GetCountryList().OrderBy(q => q).ToList();
            CategoryComboBox.DataSource = CategoryComboBox.Items;
            this.edited = edits;
            if (idJob!= null)
            {
                this.idJob = idJob;
            } 
        }
        private void loadJobForEdit(string idJob)
        {
            DB db = new DB();
            string queryInfo = $"SELECT title, body, dateFinish, budget, isOrder, id_vacancy, image, image_2, image_3, image_4, image_5, keyWord, category " +
                $"FROM jobs WHERE id_jobs = '{idJob}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                titleInput.Text = reader[0].ToString();
                this.Text = reader[0].ToString();
                bodyInput.Text = reader[1].ToString();
                dateFinishTime.Value = DateTime.Parse(reader[2].ToString());
                budgetInput.Text = reader[3].ToString();
                this.isOrder = (bool)reader[4];
                if (!isOrder && (reader[5].ToString() != ""))
                {
                    this.idVacancy = reader[5].ToString();
                }

                if (!isOrder)
                {
                    string ifImage = "";
                    if (ifImage != reader[6].ToString())
                    {
                        System.Drawing.Image image = (Bitmap)((new ImageConverter()).ConvertFrom(reader[6]));
                        coverPictureBox.Image = image;
                        coverPictureBox.Visible = true;
                    }
                }
                keyWordInput.Text = reader[11].ToString();
                CategoryComboBox.SelectedItem= reader[12].ToString();
                changeCategory = reader[12].ToString();
            }
            reader.Close();

            
            if (!isOrder)
            {
                string queryInfo3 = $"SELECT format, timetable, special, country FROM vacancy WHERE id_vacancy = '{idVacancy}'";
                MySqlCommand mySqlCommand3 = new MySqlCommand(queryInfo3, db.getConnection());

                MySqlDataReader reader3 = mySqlCommand3.ExecuteReader();
                while (reader3.Read())
                {
                    
                        foreach (Guna2Panel pn in this.Controls.OfType<Guna2Panel>())
                        {
                            foreach (Guna2Panel pn2 in pn.Controls.OfType<Guna2Panel>())
                            {
                            for (int i = 0; i < 3; i++)
                            {
                                foreach (Guna2Panel pn3 in pn2.Controls.OfType<Guna2Panel>())
                                {
                                    foreach (Guna2CustomRadioButton rb in pn3.Controls.OfType<Guna2CustomRadioButton>())
                                    {
                                        if (rb.Text == reader3[i].ToString())
                                        {
                                            rb.Checked = true;
                                        }
                                    }
                                }
                            }
                            }
                        format = reader3[0].ToString();
                        timetable = reader3[1].ToString();
                        special = reader3[2].ToString();
                        CountryComboBox.SelectedItem= reader3[3].ToString();
                        changeCountry = reader3[3].ToString();
                    }
                }
                reader3.Close();
            }

            db.closeConnection();
            guna2Panel1.Controls.Clear();
            pictureNumber = 0;

            guna2Button3.Text = "Сохранить";

            iconButton1.Visible = false;
            coverPictureBox.Visible = false;
            guna2Panel1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }
        private void getImage(MySqlDataReader reader, int number)
        {
            string ifImage = "";
            if (ifImage != reader[number].ToString())
            {
                System.Drawing.Image image = (Bitmap)((new ImageConverter()).ConvertFrom(reader[number]));
                imageArray[pictureNumber] = image;
                pictureNumber++;
            }
        }
        public static List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.DisplayName)))
                {
                    cultureList.Add(region.DisplayName);
                }
            }
            return cultureList;
        }
        private void updateJob()
        {
            if (!isOrder)
            {
                Image image = returnImage(coverPictureBox);
                imageArray[0] = image;
            }
            bool res1 = false;
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE jobs SET title=@title, body=@body, dateFinish=@df, " +
                "budget=@budget, keyWord=@kw, category=@categ Where id_jobs = @idJ", db.getConnection());

            command.Parameters.AddWithValue("@title", titleInput.Text);
            command.Parameters.AddWithValue("@body", bodyInput.Text);
            command.Parameters.AddWithValue("@df", dateFinishTime.Value.ToString("dd.MM.yyyy"));
            command.Parameters.AddWithValue("@budget", budgetInput.Text);
            command.Parameters.AddWithValue("@kw", keyWordInput.Text);
            command.Parameters.AddWithValue("@categ", changeCategory);
            command.Parameters.AddWithValue("@idJ", idJob);

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                res1 = true;
                if (idVacancy == null)
                {
                    ViewJobs vj = new ViewJobs(of, int.Parse(idJob));
                    of(vj);
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

            db.closeConnection();

            if (idVacancy!=null)
            {
                DB db2 = new DB();

                MySqlCommand command2 = new MySqlCommand("UPDATE vacancy SET format=@format, timetable=@timetable, special=@special, country=@country Where id_vacancy = @idV", db2.getConnection());

                command2.Parameters.AddWithValue("@format", format);
                command2.Parameters.AddWithValue("@timetable", timetable);
                command2.Parameters.AddWithValue("@special", special);
                command2.Parameters.AddWithValue("@country", changeCountry);
                command2.Parameters.AddWithValue("@idV", idVacancy);

                db2.openConnection();

                if (command2.ExecuteNonQuery() == 1 && res1)
                {
                    ViewJobs vj = new ViewJobs(of, int.Parse(idJob));
                    of(vj);
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                db2.closeConnection();
            }
        }

        private void orderLoad()
        {
            label1.Text = "Что нужно сделать?";
            label2.Text = "Описание задачи";
            label3.Text = "Фото";
            label4.Text = "Загрузите до 5 фото не больше 16мб";
            label5.Text = "Боджет и срок";
            budgetInput.PlaceholderText = "Укажите бюджет";

            dateFinishPanel.Visible = true;
            vacancyPanel.Visible = false;
            countryPanel.Visible = false;

            panelSelection.Visible = false;
            orderPanel.Visible = true;
            guna2Panel1.Visible = true;

            orderPanel.Dock = DockStyle.Fill;

            isOrder = true;

            keyWordPanel.Location = new Point(401, 139);
        }
        private void notOrderLoad()
        {
            label1.Text = "Кого вы ищите?";
            label2.Text = "Описание вакансии";
            label3.Text = "Обложка вакансии";
            label4.Text = "Загрузите изображение не больше 16 мб";
            label5.Text = "Примерная ежемесячная зарплата";
            budgetInput.PlaceholderText = "Укажите зарплату";

            dateFinishPanel.Visible = false;
            vacancyPanel.Visible = true;
            countryPanel.Visible = true;

            panelSelection.Visible = false;
            orderPanel.Visible = true;
            guna2Panel1.Visible = false;

            orderPanel.Dock = DockStyle.Fill;

            isOrder = false;

            keyWordPanel.Location = new Point(401, 315);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            orderLoad();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           notOrderLoad();
        }

        private void AddJobs_Load(object sender, EventArgs e)
        {
            if (!edited)
            {
                panelSelection.Dock = DockStyle.Fill;
                orderPanel.Visible = false;
                budgetPanel.Visible = false;
            }
            else
            {
                panelSelection.Visible = false;
                orderPanel.Dock = DockStyle.Fill;
                budgetPanel.Visible = false;
                guna2Button5.Visible = false;
                loadJobForEdit(idJob);
                if (isOrder)
                {
                    orderLoad();
                }
                else
                {
                    notOrderLoad();
                }
            }
        }
        private void createPictureBoxs(Image image, bool changed)
        {
            if (pictureNumber != 5)
            {
                Guna2PictureBox picture = new Guna2PictureBox
                {
                    Name = $"pictureBox{pictureNumber}",
                    Size = new Size(45, 45),
                    Location = new Point(60 * pictureNumber, 0),
                    Image = image,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand,
                    Tag = $"_{pictureNumber}"
                };
                pictureArray[pictureNumber] = picture;
                guna2Panel1.Controls.Add(picture);
                if (changed)
                    imageArray[pictureNumber] = image;
                pictureNumber++;
                picture.Click += openImageForm;
            }
        }
        private void deleteImage()
        {
            guna2Panel1.Controls.Clear();
            Array.Clear(pictureArray, 0, pictureArray.Length);
            for (int i = 0; i < 4; i++)
            {
                if (i>selectedImage)
                {
                    imageArray[i - 1] = imageArray[i];
                }
            }
            int sizeImage = pictureNumber - 1;
            pictureNumber = 0;
            for (int i = 0; i < sizeImage; i++)
            {
                createPictureBoxs(imageArray[i], false);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;

            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                if (isOrder == true)
                {
                    createPictureBoxs(image, true);
                }
                else if(isOrder == false)
                {
                    coverPictureBox.Image = image;
                    coverPictureBox.Visible= true;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;

            if (titleInput.Text.Length == 0)
            {
                titleError.Text = "Введите текст";
                titleError.Visible = true;
            }
            else if (bodyInput.Text.Length == 0)
            {
                bodyInput.PlaceholderForeColor= Color.Red;
            }
            else
            {
                budgetPanel.Visible = true;
                orderPanel.Visible = false;
                budgetPanel.Dock = DockStyle.Fill;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            budgetPanel.Visible = false;
            orderPanel.Visible = true;
            orderPanel.Dock = DockStyle.Fill;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;

            orderPanel.Visible = false;
            panelSelection.Visible = true;
            panelSelection.Dock = DockStyle.Fill;
        }

        private Image returnImage(PictureBox picture)
        {
            if (picture!=null)
            {
                return picture.Image;
            }
            return null;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (edited)
            {
                updateJob();
            }
            else
            {
                BLL objbll = new BLL();
                if (isOrder == true)
                {
                    if (budgetInput.Text.Length == 0)
                    {
                        budgetError.Text = "Минимальная сумма 20 BYN";
                        budgetError.Visible = true;
                    }
                    else if (int.Parse(budgetInput.Text) < 20)
                    {
                        budgetError.Text = "Минимальная сумма 20 BYN";
                        budgetError.Visible = true;
                    }
                    else
                    if (dateFinishTime.Value.Date <= DateTime.UtcNow.Date)
                    {
                        dateFinishError.Text = "Выберите дату";
                        dateFinishError.Visible = true;
                    }
                    else
                    if (keyWordInput.Text.Length == 0)
                    {
                        keyWordInput.Text = "Введите ключевое слово";
                        keyWordInput.Visible = true;
                    }
                    else
                    if (objbll.SaveItemJobs(titleInput.Text, bodyInput.Text, int.Parse(budgetInput.Text), dateFinishTime.Value.ToString("dd.MM.yyyy"),
                        isOrder,
                        changeCategory,
                        keyWordInput.Text,
                        returnImage(pictureArray[1]),
                        returnImage(pictureArray[0]),
                        returnImage(pictureArray[2]),
                        returnImage(pictureArray[3]),
                        returnImage(pictureArray[4])))
                    {
                        Lenta ln = new Lenta(of);
                        of(ln);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
                else if (isOrder == false)
                {
                    if (budgetInput.Text.Length == 0)
                    {
                        budgetError.Text = "Минимальная сумма 554 BYN";
                        budgetError.Visible = true;
                    }
                    else if (int.Parse(budgetInput.Text) < 554)
                    {
                        budgetError.Text = "Минимальная сумма 544 BYN";
                        budgetError.Visible = true;
                    }
                    else
                    if (keyWordInput.Text.Length == 0)
                    {
                        keyWordInput.Text = "Введите ключевое слово";
                        keyWordInput.Visible = true;
                    }
                    else if (objbll.SaveItemVacancy(format, timetable, special, changeCountry))
                    {
                        if (objbll.SaveItemJobs(titleInput.Text, bodyInput.Text, int.Parse(budgetInput.Text), DateTime.UtcNow.Date.ToString("dd.MM.yyyy"),
                            isOrder,
                            changeCategory,
                            keyWordInput.Text,
                            coverPictureBox.Image, null, null, null, null))
                        {
                            Lenta ln = new Lenta(of);
                            of(ln);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
            }
        }

        private void budgetInput_TextChanged(object sender, EventArgs e)
        {
            budgetError.Visible = false;
        }

        private void dateFinishTime_ValueChanged(object sender, EventArgs e)
        {
            dateFinishError.Visible = false;
        }

        private void titleInput_TextChanged(object sender, EventArgs e)
        {
            titleError.Visible = false;

        }

        private void bodyInput_TextChanged(object sender, EventArgs e)
        {
            bodyInput.PlaceholderForeColor = Color.FromArgb(69, 162, 158);

        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            format = guna2CustomRadioButton1.Text;
        }

        private void countryInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            format = guna2CustomRadioButton2.Text;
        }

        private void guna2CustomRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            format = guna2CustomRadioButton3.Text;
        }

        private void guna2CustomRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            format = guna2CustomRadioButton4.Text;
        }

        private void guna2CustomRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            timetable = guna2CustomRadioButton8.Text;
        }

        private void guna2CustomRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            timetable = guna2CustomRadioButton7.Text;
        }

        private void guna2CustomRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            timetable = guna2CustomRadioButton6.Text;
        }

        private void guna2CustomRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            timetable = guna2CustomRadioButton5.Text;
        }

        private void guna2CustomRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            special = guna2CustomRadioButton12.Text;
        }

        private void guna2CustomRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            special = guna2CustomRadioButton11.Text;
        }

        private void guna2CustomRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            special = guna2CustomRadioButton10.Text;
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            selectedImage--;
            if (selectedImage < 0)
                selectedImage = pictureNumber-1;
            imagePanel.Image= imageArray[selectedImage];
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            selectedImage++;
            if (selectedImage > pictureNumber-1)
                selectedImage = 0;
            imagePanel.Image = imageArray[selectedImage];
        }

        private void orderPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void orderPanel_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
        }

        private void titleInput_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
        }

        private void bodyInput_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
        }

        private void coverPictureBox_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = true;
            imagePanel.Image = coverPictureBox.Image;
            iconPictureBox3.Visible = false;
            iconPictureBox2.Visible = false;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            deleteImage();
            imagePanel.Image = imageArray[selectedImage];
            if (pictureNumber==0)
                viewImagePanel.Visible = false;
            if (pictureNumber == 1)
            {
                iconPictureBox3.Visible= false;
                iconPictureBox2.Visible = false;
            }
        }

        private void CountryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            changeCountry = CountryComboBox.SelectedValue.ToString();
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
            {
                changeCountry = null;
                CountryComboBox.Enabled = false;
            }
            else if (!guna2CustomCheckBox1.Checked)
            {
                CountryComboBox.Enabled = true;
                changeCountry = CountryComboBox.SelectedValue.ToString();
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            keyWordError.Visible = false;
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCategory= CategoryComboBox.SelectedValue.ToString();
        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            selectedImage--;
            if (selectedImage < 0)
                selectedImage = pictureNumber - 1;
            imagePanel.Image = imageArray[selectedImage];
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            selectedImage++;
            if (selectedImage > pictureNumber - 1)
                selectedImage = 0;
            imagePanel.Image = imageArray[selectedImage];
        }
    }
}
