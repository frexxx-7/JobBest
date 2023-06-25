using Guna.UI2.WinForms;
using JobBest.Classes;
using JobBest.Controls;
using JobBest.JobsForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace JobBest.Forms
{
    public partial class Lenta : Form
    {
        AppPage.OpenForm of;
        double lastPageRows;
        double numberPage;
        double _startRows = 0;
        string jobsPanelMeaning = null;
        Guna2Panel jobsPanell;
        double _numberRows = 10;
        TabPage activeTabPage;

        private delegate void addPanelControls(Guna2Panel panel);
        private addPanelControls addControls;

        private delegate void addLoaderToPanel();
        private addLoaderToPanel addLoader;

        private delegate void viewPanelJobs(Guna2Panel panel);
        private viewPanelJobs viewPanel;

        bool isAscending= false;
        private string changeCountry = null;

        private string changeCategory = null;

        private string budgetStart = null;

        private string budgetEnd = null;

        private string keyWord = null;

        public Lenta(AppPage.OpenForm OpenChildForm)
        {
            InitializeComponent();
            of = OpenChildForm;
            jobsPanell = jobsPanel;
            addControls = new addPanelControls(addControlsPanel);
            addLoader = new addLoaderToPanel(addedLoader);
            viewPanel = new viewPanelJobs(viewPanels);
            activeTabPage = tabPageAll;
            guna2TabControl1.Width += filterPanel.Width;
            CountryComboBox.DataSource = GetCountryList().OrderBy(q => q).ToList();
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

        private void viewPanels(Guna2Panel panel)
        {
            panel.Visible = true;
        }
        private void addedLoader()
        {
            activeTabPage.Controls.Add(guna2PictureBox1);
            guna2PictureBox1.BringToFront();
            guna2PictureBox1.Dock = DockStyle.Fill;
            jobsPanell.Controls.Clear();
        }
        private void calcPages(string isOrder)
        {
            string whereQuery = null;

            if (changeCategory != null)
            {
                whereQuery = $"(category='{changeCategory}') AND ";
            }
            if (changeCountry != null)
            {
                whereQuery += $"(country='{changeCountry}') AND ";
            }
            if (budgetStart != null)
            {
                whereQuery += $"(budget BETWEEN {budgetStart} AND {budgetEnd}) AND ";
            }
            if (keyWord != null)
            {
                whereQuery += $"(keyWord='{keyWord}') AND ";
            }
            if (whereQuery != null)
            {
                whereQuery = whereQuery.Remove(whereQuery.Length - 5);
            }

            double numberRows = 0;
            DB db = new DB();
            string sort = isAscending ? "ASC" : "DESC";
            string queryInfo = isOrder != null ?
                    $"SELECT count(*) FROM jobs " +
                    $"LEFT JOIN vacancy ON vacancy.id_vacancy = jobs.id_vacancy " +
                    $"WHERE isOrder={isOrder} {(whereQuery != null ? $"AND {whereQuery} " : "")}" +
                    $"ORDER BY id_jobs {sort} "
                    :
                    $"SELECT count(*) FROM jobs " +
                    $"LEFT JOIN vacancy ON vacancy.id_vacancy = jobs.id_vacancy " +
                    $"{(whereQuery != null ? $"WHERE {whereQuery} " : "")}" +
                    $"ORDER BY id_jobs {sort} ";

            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());
            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                numberRows = int.Parse(reader[0].ToString());
            }
            reader.Close();

            db.closeConnection();

            _startRows = 0;
            numberPage = Math.Ceiling((numberRows / _numberRows));
            lastPageRows = numberRows - (numberPage - 1) * _numberRows;
            previousPageLabel.Visible = false;
            label3.Visible = false;
            label6.Text = numberPage.ToString();
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = false;
            label9.Visible = false;
            nextPageLabel.Visible = true;
            label3.Text = "0";
            label4.Text = "1";
            label5.Text = "...";
            label7.Text = "2";
            label8.Text = "...";
            label9.Text = "1";

            if (numberPage == 0)
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                nextPageLabel.Visible = false;
                previousPageLabel.Visible = false;
                label4.Text = "0";
            }

            if (numberPage == 1)
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                nextPageLabel.Visible = false;
            }

            if (numberPage == 2)
            {
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            if (numberPage == 3)
            {
                label5.Text = 3.ToString();
                label5.Cursor = Cursors.Hand;
                label6.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
        }
        private void examinationPlus()
        {
            previousPageLabel.Visible = true;
            label3.Visible = true;
            jobsPanell.Controls.Clear();
            if (numberPage == 3)
            {
                label5.Visible = false;
                label6.Visible = false;
            }
            if (int.Parse(label4.Text) == 3)
            {
                label8.Text = "1";
                label8.Cursor = Cursors.Hand;
                label8.Visible = true;
            }
            if (int.Parse(label4.Text) >= 4)
            {
                label9.Visible = true;
                label8.Visible = true;
                label8.Text = "...";
                label8.Cursor = Cursors.Default;
            }
            if (int.Parse(label7.Text) == numberPage)
            {
                label5.Visible = false;
                label6.Visible = false;
            }
            if (numberPage == double.Parse(label4.Text))
            {
                _numberRows = lastPageRows;
                jobsPanell.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker1.RunWorkerAsync();

                label7.Visible = false;
                nextPageLabel.Visible = false;
            }
            else
            {
                jobsPanell.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void examinationMinus()
        {
            nextPageLabel.Visible = true;
            label7.Visible = true;
            jobsPanell.Controls.Clear();

            if (int.Parse(label4.Text)+2 == numberPage)
            {
                label5.Text = "...";
                label5.Visible = true;
                label6.Visible = true;
            }

            if (int.Parse(label4.Text) == 3)
            {
                label9.Visible = false;
                label8.Text = "1";
                label8.Cursor = Cursors.Hand;
            }
            else
            if (int.Parse(label4.Text) == 2)
            {
                label8.Visible = false;
                label5.Visible = true;
                label6.Visible = true;

                if (numberPage == 3)
                {
                    label5.Visible = false;
                    label6.Visible = false;
                }
            }
            else if (int.Parse(label4.Text) == 1)
            {
                label3.Visible = false;
                previousPageLabel.Visible = false;

                if (numberPage == 3)
                {
                    label5.Text = 3.ToString();
                    label5.Cursor = Cursors.Hand;
                    label6.Visible = false;
                }
            }
            jobsPanell.Visible = false;
            guna2PictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoLabel.Text = guna2TabControl1.SelectedTab.Text;
            _startRows = 0;
            if (guna2TabControl1.SelectedTab.Name == "tabPageOrders")
            {
                changeCountry = null;
                activeTabPage = tabPageOrders;
                removeControls("0");
                removeControls(null);
                jobsPanelMeaning = "1";
                jobsPanell = ordersPanel;
                calcPages(jobsPanelMeaning);
                jobsPanell.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
                countryPanel.Visible = false;
                guna2Panel7.Location = new Point(8, 131);
            }
            else if (guna2TabControl1.SelectedTab.Name == "tabPageVacancy")
            {
                changeCountry = null;
                activeTabPage = tabPageVacancy;
                removeControls("1");
                removeControls(null);
                jobsPanelMeaning = "0";
                jobsPanell = vacancyPanel;
                calcPages(jobsPanelMeaning);
                jobsPanell.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
                countryPanel.Visible = true;
                guna2Panel7.Location = new Point(8, 209);
            }
            else if (guna2TabControl1.SelectedTab.Name == "tabPageAll")
            {
                changeCountry = null;
                activeTabPage = tabPageAll;
                removeControls("0");
                removeControls("1");
                jobsPanelMeaning = null;
                jobsPanell = jobsPanel;
                calcPages(jobsPanelMeaning);
                jobsPanell.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
                countryPanel.Visible = true;
                guna2Panel7.Location = new Point(8, 209);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddJobs addjobs = new AddJobs(of,false, null);
            of.Invoke(addjobs);
        }

        private void addControlsPanel(Guna2Panel panel)
        {
            jobsPanell.Controls.Add(panel);
            panel.BringToFront();
        }

        private void GenerateDynamicAllUserControl(string isOrder, double startRows , double numberRows, bool isAscending)
        {
            BLL objbll = new BLL();

            DataTable dt = objbll.GetItems("jobs", isOrder, startRows, numberRows, isAscending, changeCategory, changeCountry, budgetStart, budgetEnd, keyWord);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    JobsControls[] listItems = new JobsControls[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"orderPanel+{panelNumber}",
                                Size = new Size(630, 200),
                                Location = new Point(30, 200 * panelNumber + 20),
                                //Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                                Dock = DockStyle.Top,
                            };
                            listItems[i] = new JobsControls(of);
                            listItems[i].Head = row["title"].ToString();
                            listItems[i].Body = row["body"].ToString();
                            listItems[i].Date = row["date"].ToString();
                            listItems[i].Budget = int.Parse(row["budget"].ToString());
                            listItems[i].id_jobs = int.Parse(row["id_jobs"].ToString());
                            listItems[i].isOrder = (bool)row["isORder"];
                            if (row["image"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["image"]);
                                listItems[i].Picture = new Bitmap(ms);
                            }
                            listItems[i].Dock = DockStyle.Top;

                            panel.Controls.Add(listItems[i]);
                            jobsPanell.Invoke(addControls, panel);
                            panelNumber++;
                            //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }

                    }
                }
            }

        }

        private void removeControls(string isOrder)
        {
            if (isOrder == null)
            {
                jobsPanel.Controls.Clear();
            }
            else if (isOrder == "0")
            {
                vacancyPanel.Controls.Clear();
            }
            else if (isOrder == "1")
            {
                ordersPanel.Controls.Clear();
            }
        }

        private void Lenta_Load(object sender, EventArgs e)
        {
            calcPages(jobsPanelMeaning);
            jobsPanell.Visible = false;
            guna2PictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();

            if (numberPage == 1)
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                nextPageLabel.Visible = false;
            }else
            if (numberPage == 2) { 
                label6.Visible = false;
                label5.Visible = false;
            } else 
            if (numberPage == 3)
            {
                label6.Visible = false;
                label5.Text = "3";
            }

            CategoryComboBox.DataSource = CategoryComboBox.Items;
            if (AppPage.isWorker)
            {
                guna2Button6.Visible = false;
            }
        }

        private void nextPageLabel_Click(object sender, EventArgs e)
        {
            label4.Text = (int.Parse(label4.Text)+1).ToString();
            label3.Text = (int.Parse(label3.Text)+1).ToString();
            label7.Text = (int.Parse(label7.Text)+1).ToString();
            _startRows += 10;
            examinationPlus();
        }

        private void previousPageLabel_Click(object sender, EventArgs e)
        {
            label3.Text = (int.Parse(label3.Text) - 1).ToString();
            label4.Text = (int.Parse(label4.Text) - 1).ToString();
            label7.Text = (int.Parse(label7.Text) - 1).ToString();
            _startRows -= 10;

            examinationMinus();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            _startRows = 0;
            previousPageLabel.Visible = false;
            label3.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label4.Text = 1.ToString();
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label7.Text = 2.ToString();
            label3.Text = 0.ToString();
            nextPageLabel.Visible = true;
            jobsPanell.Visible = false;
            guna2PictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (label8.Text != "...")
            {
                if (int.Parse(label8.Text) == 1)
                {
                    _startRows = 0;
                    previousPageLabel.Visible = false;
                    label3.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label4.Text = 1.ToString();
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label7.Text = 2.ToString();
                    label3.Text = 0.ToString();
                    nextPageLabel.Visible = true;
                    jobsPanell.Visible = false;
                    guna2PictureBox1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            _startRows = (double.Parse(label3.Text)-1)*10;
            label3.Text = (int.Parse(label3.Text) - 1).ToString();
            label4.Text = (int.Parse(label4.Text) - 1).ToString();
            label7.Text = (int.Parse(label7.Text) - 1).ToString();
            examinationMinus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
            _startRows = (double.Parse(label7.Text)-1) * 10;
            label4.Text = (int.Parse(label4.Text) + 1).ToString();
            label3.Text = (int.Parse(label3.Text) + 1).ToString();
            label7.Text = (int.Parse(label7.Text) + 1).ToString();
            examinationPlus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            _startRows = (double.Parse(label6.Text)-1) * 10;
            label4.Text = int.Parse(label6.Text).ToString();
            label3.Text = (int.Parse(label4.Text)-1).ToString();
            label7.Text = (numberPage+1).ToString();
            label5.Visible= false;
            label6.Visible= false;
            examinationPlus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text != "...")
            {
                if (int.Parse(label5.Text) == numberPage)
                {
                    _startRows = (double.Parse(label6.Text) - 1) * 10;
                    label4.Text = int.Parse(label6.Text).ToString();
                    label3.Text = (int.Parse(label4.Text) - 1).ToString();
                    label7.Text = (numberPage + 1).ToString();
                    label5.Visible = false;
                    label6.Visible = false;
                    examinationPlus();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            tabPageAll.Invoke(addLoader);
            GenerateDynamicAllUserControl(jobsPanelMeaning, _startRows, _numberRows, isAscending);
            jobsPanell.Invoke(viewPanel, jobsPanell);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            guna2PictureBox1.Visible = false;
            _numberRows = 10;
            tabPageAll.Controls.Remove(guna2PictureBox1);
            tabPageOrders.Controls.Remove(guna2PictureBox1);
            tabPageVacancy.Controls.Remove(guna2PictureBox1);
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            jobsPanell.Visible = false;

            if (guna2CustomCheckBox1.Checked)
            {
                filterPanel.Visible = true;
                guna2TabControl1.Width -= filterPanel.Width;
            } else if (!guna2CustomCheckBox1.Checked)
            {
                guna2TabControl1.Width += filterPanel.Width;
                filterPanel.Visible = false;
            }
            Task.Delay(5).ContinueWith((task) => { jobsPanell.Invoke(viewPanel, jobsPanell); });
        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            isAscending = !isAscending;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked)
            {
                changeCountry = null;
                CountryComboBox.Enabled = false;
            }
            else if (!guna2CustomCheckBox3.Checked)
            {
                CountryComboBox.Enabled = true;
                changeCountry = CountryComboBox.SelectedValue.ToString();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (keyWordInput.Text.Length!=0)
            {
                keyWord = keyWordInput.Text;
            }
            else
            {
                keyWord = null;
            }
            if (budgetInput.Text.Length == 0 && budgetInput2.Text.Length== 0)
            {
                budgetStart = null;
                budgetEnd = null;
                jobsPanell.Visible = false;
                guna2PictureBox1.Visible = true;
                calcPages(jobsPanelMeaning);
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                if (int.Parse(budgetInput.Text) < 20 || int.Parse(budgetInput2.Text) < 21)
                {
                    budgetError.Text = "Некорректные данные";
                    budgetError.Visible = true;
                }
                else
                {
                    budgetStart = budgetInput.Text;
                    budgetEnd = budgetInput2.Text;
                    jobsPanell.Visible = false;
                    guna2PictureBox1.Visible = true;
                    calcPages(jobsPanelMeaning);
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void guna2CustomCheckBox4_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox4.Checked)
            {
                changeCategory = null;
                CategoryComboBox.Enabled = false;
            }
            else if (!guna2CustomCheckBox4.Checked)
            {
                CategoryComboBox.Enabled = true;
                changeCategory = CategoryComboBox.SelectedValue.ToString();
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void budgetInput_TextChanged(object sender, EventArgs e)
        {
            budgetError.Visible = false;
        }

        private void budgetInput2_TextChanged(object sender, EventArgs e)
        {
            budgetError.Visible = false;
        }

        private void CategoryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void CountryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            changeCountry = CountryComboBox.SelectedValue.ToString();
        }

        private void CategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            changeCategory = CategoryComboBox.SelectedValue.ToString();
        }
    }
}
