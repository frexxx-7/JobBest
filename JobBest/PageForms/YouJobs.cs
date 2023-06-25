using Guna.UI2.WinForms;
using JobBest.Classes;
using JobBest.Controls;
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

namespace JobBest.PageForms
{
    public partial class YouJobs : Form
    {
        AppPage.OpenForm of;
        double _startRows = 0;
        double _numberRows = 10;
        double lastPageRows;
        double numberPage;

        private delegate void addPanelControls(Guna2Panel panel);
        private addPanelControls addControls;

        private delegate void addLoaderToPanel();
        private addLoaderToPanel addLoader;

        private delegate void viewPanelJobs(Guna2Panel panel);
        private viewPanelJobs viewPanel;

        private string searchText = null;

        public YouJobs(AppPage.OpenForm OpenChildForm)
        {
            InitializeComponent();
            of = OpenChildForm;
            addControls = new addPanelControls(addControlsPanel);
            addLoader = new addLoaderToPanel(addedLoader);
            viewPanel = new viewPanelJobs(viewPanels);
        }
        private void addControlsPanel(Guna2Panel panel)
        {
            jobsPanel.Controls.Add(panel);
            panel.BringToFront();
        }
        private void viewPanels(Guna2Panel panel)
        {
            panel.Visible = true;
        }
        private void addedLoader()
        {
            jobsPanel.Controls.Clear();
            mainPanel.Controls.Add(guna2PictureBox1);
            guna2PictureBox1.BringToFront();
            guna2PictureBox1.Dock = DockStyle.Fill;
        }

        private void GenerateDynamicAllUserControl()
        {
            BLL objbll = new BLL();

            DataTable dt = objbll.GetYouItems(int.Parse(AppPage.idInfo), _startRows, _numberRows, searchText);

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
                            jobsPanel.Invoke(addControls, panel);
                            panelNumber++;
                            //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }

                    }
                }
            }

        }
        private void GenerateDynamicAllUserControlWorker()
        {
            BLL objbll = new BLL();

            DataTable dt = objbll.GetYouItemsWork(int.Parse(AppPage.idInfo), _startRows, _numberRows, searchText);

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
                            jobsPanel.Invoke(addControls, panel);
                            panelNumber++;
                            //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }

                    }
                }
            }

        }
        private void calcPages()
        {
            double numberRows = 0;
            DB db = new DB();
            string queryInfo = searchText==null ? 
                    $"SELECT count(*) FROM jobs " +
                    $"WHERE id_user = {AppPage.idInfo} "
                    :
                    $"SELECT count(*) FROM jobs " +
                    $"WHERE id_user = {AppPage.idInfo} AND title LIKE '{searchText}%' ";

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
            jobsPanel.Controls.Clear();
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
                jobsPanel.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker1.RunWorkerAsync();

                label7.Visible = false;
                nextPageLabel.Visible = false;
            }
            else
            {
                jobsPanel.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void examinationMinus()
        {
            nextPageLabel.Visible = true;
            label7.Visible = true;
            jobsPanel.Controls.Clear();

            if (int.Parse(label4.Text) + 2 == numberPage)
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
            jobsPanel.Visible = false;
            guna2PictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void YouJobs_Load(object sender, EventArgs e)
        {
            calcPages();
            jobsPanel.Visible = false;
            guna2PictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void nextPageLabel_Click(object sender, EventArgs e)
        {
            label4.Text = (int.Parse(label4.Text) + 1).ToString();
            label3.Text = (int.Parse(label3.Text) + 1).ToString();
            label7.Text = (int.Parse(label7.Text) + 1).ToString();
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
            jobsPanel.Visible = false;
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
                    jobsPanel.Visible = false;
                    guna2PictureBox1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            _startRows = (double.Parse(label3.Text) - 1) * 10;
            label3.Text = (int.Parse(label3.Text) - 1).ToString();
            label4.Text = (int.Parse(label4.Text) - 1).ToString();
            label7.Text = (int.Parse(label7.Text) - 1).ToString();
            examinationMinus();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            _startRows = (double.Parse(label7.Text) - 1) * 10;
            label4.Text = (int.Parse(label4.Text) + 1).ToString();
            label3.Text = (int.Parse(label3.Text) + 1).ToString();
            label7.Text = (int.Parse(label7.Text) + 1).ToString();
            examinationPlus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            _startRows = (double.Parse(label6.Text) - 1) * 10;
            label4.Text = int.Parse(label6.Text).ToString();
            label3.Text = (int.Parse(label4.Text) - 1).ToString();
            label7.Text = (numberPage + 1).ToString();
            label5.Visible = false;
            label6.Visible = false;
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
            mainPanel.Invoke(addLoader);
            if (!AppPage.isWorker)
                GenerateDynamicAllUserControl();
            else
                GenerateDynamicAllUserControlWorker();
            jobsPanel.Invoke(viewPanel, jobsPanel);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            guna2PictureBox1.Visible = false;
            _numberRows = 10;
            mainPanel.Controls.Remove(guna2PictureBox1);
        }

        private void keyWordInput_TextChanged(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            searchText = searchInput.Text;
            calcPages();
            jobsPanel.Visible = false;
            guna2PictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
