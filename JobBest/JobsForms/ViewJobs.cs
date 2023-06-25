using Guna.UI2.WinForms;
using JobBest.Classes;
using JobBest.Classes.Messages;
using JobBest.Classes.Responses;
using JobBest.Controls;
using JobBest.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static JobBest.AppPage;

namespace JobBest.JobsForms
{
    public partial class ViewJobs : Form
    {
        AppPage.OpenForm of;
        private int idJobs;
        private int idUser;
        private bool isOrder;
        private int idVacancy;
        private Image[] imageArray = new Image[5];
        private int pictureNumber = 0;
        private int selectedImage;
        private bool youResponse = false;
        private bool isCreator = false;
        private string idExecutor = null;

        private delegate void addPanelControls(Guna2Panel panel, Guna2Panel parentPanel);
        private addPanelControls addControls;

        private delegate void viewPanelChats(Guna2Panel panel);
        private viewPanelChats viewPanel;

        public delegate void clearPanel(Guna2Panel panel);
        private clearPanel clearControlsPanel;

        private delegate void addLoaderToPanel(Guna2Panel parentPanel, Guna2Panel panel);
        private addLoaderToPanel addLoader;

        public delegate void viewResponses(int idUser);
        private viewResponses responses;

        public ViewJobs(AppPage.OpenForm OpenChildForm, int idJobs)
        {
            InitializeComponent();
            of = OpenChildForm;
            this.idJobs= idJobs;
            if (AppPage.isWorker ) {
                responseButton.Visible = true;
            }else if (!AppPage.isWorker ) {
                responseButton.Visible=false;
            }
            viewImagePanel.Location = new Point(176, 128);
            addControls = new addPanelControls(addControlsPanel);
            viewPanel = new viewPanelChats(viewPanels);
            clearControlsPanel = new clearPanel(clearVoidPanel);
            addLoader = new addLoaderToPanel(addedLoader);
            responses = new viewResponses(viewBackResponses);
        }
        private void viewBackResponses(int idUser)
        {
            responsesPanel.Visible = true;
            viewImagePanel.Visible = false;

            responsesContentPanel.Invoke(addLoader, responsesContentPanel, ResponsePanel);
            backgroundWorker1.RunWorkerAsync();
            idExecutor = idUser.ToString();
        }
        private void searchUserInResponses()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id_user, id_job FROM responses WHERE (id_user = {AppPage.idInfo}) AND (id_job = {idJobs})";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (!reader.HasRows)
            {
                youResponse = false;
            }

            while (reader.Read())
            {
                if (reader[0].ToString() != null)
                    youResponse = true;
            }

            reader.Close();

            db.closeConnection();
        }
        private void addControlsPanel(Guna2Panel panel, Guna2Panel parentPanel)
        {
            parentPanel.Controls.Add(panel);
            panel.BringToFront();
            parentPanel.VerticalScroll.Value = parentPanel.VerticalScroll.Maximum;
        }
        private void viewPanels(Guna2Panel panel)
        {
            panel.Visible = true;
        }
        private void clearVoidPanel(Guna2Panel panel)
        {
            ResponsePanel.Controls.Clear();
        }
        private void addedLoader(Guna2Panel parentPanel, Guna2Panel panel)
        {
            parentPanel.Controls.Add(guna2PictureBox1);
            guna2PictureBox1.BringToFront();
            guna2PictureBox1.Dock = DockStyle.Fill;
            panel.Controls.Clear();
        }
        private void openImageForm(object sender, EventArgs e)
        {
            responsesPanel.Visible = false;
            viewImagePanel.Visible = true;
            Guna2PictureBox pictureBox = (Guna2PictureBox)sender;
            imagePanel.Image = pictureBox.Image;
            selectedImage = int.Parse(pictureBox.Tag.ToString()[1].ToString());
            if (pictureNumber - 1 == 0)
            {
                iconPictureBox1.Visible = false;
                iconPictureBox2.Visible = false;
            }
            else
            {
                iconPictureBox1.Visible = true;
                iconPictureBox2.Visible = true;
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            of(new Lenta(of));
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
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

        private void ViewJobs_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            string queryInfo = $"SELECT title, body, date, id_user, dateFinish, budget, isOrder, id_vacancy, image, image_2, image_3, image_4, image_5, executor FROM jobs WHERE id_jobs = '{idJobs}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                headLabel.Text = reader[0].ToString();
                this.Text= reader[0].ToString();
                bodyLabel.Text = reader[1].ToString();
                dateLabel.Text = reader[2].ToString();
                idUser = int.Parse(reader[3].ToString());
                dateFinishLabel.Text = reader[4].ToString();
                budgetLabel.Text = reader[5].ToString() + " BYN";
                this.isOrder = (bool)reader[6];
                this.idExecutor = reader[13].ToString();
                if (!isOrder && (reader[7].ToString() != ""))
                {
                    this.idVacancy = (int)reader[7];
                }
                getImage(reader, 8);
                getImage(reader, 9);
                getImage(reader, 10);
                getImage(reader, 11);
                getImage(reader, 12);
            }
            reader.Close();


            string queryInfo2 = $"SELECT login, dateRegistration, image FROM users WHERE id_user = '{idUser}'";
            MySqlCommand mySqlCommand2 = new MySqlCommand(queryInfo2, db.getConnection());

            MySqlDataReader reader2 = mySqlCommand2.ExecuteReader();
            while (reader2.Read())
            {
                loginLabel.Text = reader2[0].ToString();
                dateRegistrationLabel.Text = reader2[1].ToString();
                string ifImage = "";
                if (ifImage != reader2[2].ToString())
                {
                    System.Drawing.Image avatar = (Bitmap)((new ImageConverter()).ConvertFrom(reader2[2]));
                    imagePictureBox.Image = avatar;
                    imagePictureBox.Invalidate();
                }
            }
            reader2.Close();

            if (!isOrder)
            {
                string queryInfo3 = $"SELECT format, timetable, special, country FROM vacancy WHERE id_vacancy = '{idVacancy}'";
                MySqlCommand mySqlCommand3 = new MySqlCommand(queryInfo3, db.getConnection());

                MySqlDataReader reader3 = mySqlCommand3.ExecuteReader();
                while (reader3.Read())
                {
                    bodyLabel.Text = bodyLabel.Text + $"\n \n \n \n" +
                        $"Формат работы: \n   {reader3[0]} \n \n" +
                        $"График работы:\n   {reader3[1]} \n \n" +
                        $"Особые условия:\n   {reader3[2]}";
                }
                reader3.Close();
            }

            db.closeConnection();
            if (isOrder)
            {
                label5.Visible = true;
                dateFinishLabel.Visible = true;
                label4.Text = "Бюджет";
            }
            else if (!isOrder)
            {
                label5.Visible = false;
                dateFinishLabel.Visible = false;
                label4.Text = "Зарплата:";
            }
            for (int i = 0; i < 5; i++)
            {
                if (imageArray[i] != null)
                {
                    Guna2PictureBox picture = new Guna2PictureBox
                    {
                        Name = $"pictureBox{i}",
                        Size = new Size(94, 94),
                        Location = new Point(100 * i, 0),
                        Image = imageArray[i],
                        Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = $"_{i}",
                        Cursor = Cursors.Hand
                    };
                    guna2Panel6.Controls.Add(picture);
                    picture.Click += openImageForm;
                }
            }
            searchUserInResponses();
            isCreator = int.Parse(AppPage.idInfo) == idUser;
            if (youResponse || isCreator)
            {
                responseButton.Visible = false;
                guna2Button1.Location = new Point(662, 308);
            }
            if (imageArray[0]==null)
            {
                label1.Visible = false;
            }
        }
        private void GenerateDynamicResponseControls()
        {
            ResponsesBLL objbll = new ResponsesBLL();

            DataTable dt = objbll.GetItemsResponse(idJobs);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ResponsesControls[] listItems = new ResponsesControls[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"response+{panelNumber}",
                                Size = new Size(761, 106),
                                //Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top ,
                                Dock = DockStyle.Top,
                                Padding = new System.Windows.Forms.Padding(bottom: 3, left: 0, top: 0, right: 0),
                            };
                            listItems[i] = new ResponsesControls(of, idJobs, idExecutor, responses);

                            listItems[i].userID = (int)row["id_user"];
                            listItems[i].dateCreate = (DateTime)row["date_create"];
                            listItems[i].Login = row["login"].ToString();
                            listItems[i].Dock = DockStyle.Top;
                            listItems[i].isCreator = isCreator;

                            if (row["image"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["image"]);
                                listItems[i].Picture = new Bitmap(ms);
                            }


                            panel.Controls.Add(listItems[i]);
                            ResponsePanel.Invoke(addControls, panel, ResponsePanel);
                            panelNumber++;
                            //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }

                    }
                }
            }

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            selectedImage++;
            if (selectedImage > pictureNumber - 1)
                selectedImage = 0;
            imagePanel.Image = imageArray[selectedImage];
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            selectedImage--;
            if (selectedImage < 0)
                selectedImage = pictureNumber - 1;
            imagePanel.Image = imageArray[selectedImage];
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void ProfilePanel_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void headLabel_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void guna2Panel3_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void budgetLabel_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void dateFinishLabel_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void guna2Panel4_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void guna2Panel5_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void bodyLabel_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void guna2Panel6_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void responseButton_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            ResponsesBLL objbll = new ResponsesBLL();

            if (objbll.SaveItemResponse(idJobs, int.Parse(AppPage.idInfo)))
            {
                responseButton.Visible = false;
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void dateLabel_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            viewImagePanel.Visible = false;
            responsesPanel.Visible = false;
        }

        private void userInfoPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void userInfoPanel_Click(object sender, EventArgs e)
        {
            of(new Profile(idUser.ToString(), of));
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {
            of(new Profile(idUser.ToString(), of));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            of(new Profile(idUser.ToString(), of));
        }

        private void dateRegistrationLabel_Click(object sender, EventArgs e)
        {
            of(new Profile(idUser.ToString(), of));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            responsesPanel.Visible = true;
            viewImagePanel.Visible = false;

            responsesContentPanel.Invoke(addLoader, responsesContentPanel, ResponsePanel);
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            responsesContentPanel.Invoke(addLoader, responsesContentPanel, ResponsePanel);
            GenerateDynamicResponseControls();
            ResponsePanel.Invoke(viewPanel, ResponsePanel);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            guna2PictureBox1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            of(new AddJobs(of, true, idJobs.ToString()));
        }
    }
}
