using Guna.UI2.WinForms;
using JobBest.Classes;
using JobBest.Classes.Comments;
using JobBest.Classes.Responses;
using JobBest.Controls;
using JobBest.HelpForms;
using JobBest.JobsForms;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static JobBest.JobsForms.Messages;

namespace JobBest.Forms
{
    public partial class Profile : Form
    {
        private delegate void addPanelControls(Guna2Panel panel, Guna2Panel parentPanel);
        private addPanelControls addControls;

        private delegate void viewPanelChats(Guna2Panel panel);
        private viewPanelChats viewPanel;

        public delegate void clearPanel(Guna2Panel panel);
        private clearPanel clearControlsPanel;

        private delegate void addLoaderToPanel(Guna2Panel parentPanel, Guna2Panel panel);
        private addLoaderToPanel addLoader;

        AppPage.OpenForm of;
        public string idInfo;
        private bool youComment = false;
        public Profile(string idInfo, AppPage.OpenForm of)
        {
            InitializeComponent();
            this.idInfo = idInfo;
            this.of = of;
            addControls = new addPanelControls(addControlsPanel);
            viewPanel = new viewPanelChats(viewPanels);
            addLoader = new addLoaderToPanel(addedLoader);
        }
        private void addedLoader(Guna2Panel parentPanel, Guna2Panel panel)
        {
            parentPanel.Controls.Add(guna2PictureBox1);
            guna2PictureBox1.BringToFront();
            guna2PictureBox1.Dock = DockStyle.Fill;
            panel.Controls.Clear();
        }
        private void viewPanels(Guna2Panel panel)
        {
            panel.Visible = true;
        }
        private void addControlsPanel(Guna2Panel panel, Guna2Panel parentPanel)
        {
            parentPanel.Controls.Add(panel);
            panel.BringToFront();
            parentPanel.VerticalScroll.Value = parentPanel.VerticalScroll.Maximum;
        }
        private void GenerateDynamicCommentControls()
        {
            CommentsBLL objbll = new CommentsBLL();

            DataTable dt = objbll.GetItemsComment(int.Parse(idInfo));

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    CommentsControls[] listItems = new CommentsControls[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"comment+{panelNumber}",
                                Size = new Size(761, 169),
                                //Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top ,
                                Dock = DockStyle.Top,
                                Padding = new System.Windows.Forms.Padding(bottom: 3, left: 0, top: 0, right: 0),
                            };
                            listItems[i] = new CommentsControls(of);

                            listItems[i].idUser = (int)row["id_userCreator"];
                            listItems[i].DateCreate = (DateTime)row["date_create"];
                            listItems[i].Login = row["login"].ToString();
                            listItems[i].Dock = DockStyle.Top;
                            listItems[i].CommentContent = row["content"].ToString();
                            listItems[i].NumberStar = (int)row["numberStars"];

                            if (row["image"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["image"]);
                                listItems[i].Picture = new Bitmap(ms);
                            }


                            panel.Controls.Add(listItems[i]);
                            commentPanel.Invoke(addControls, panel, commentPanel);
                            panelNumber++;
                            //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }

                    }
                }
            }

        }
        private void searchUserInComment()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id_userCreator FROM comments WHERE (id_userCreator = {AppPage.idInfo}) AND (id_userComment = {idInfo})";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (!reader.HasRows)
            {
                youComment = false;
            }

            while (reader.Read())
            {
                if (reader[0].ToString() != null)
                    youComment = true;
            }

            reader.Close();

            db.closeConnection();
        }
        private void Profile_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            string queryInfo = $"SELECT login, image, dateRegistration, isWorker, password FROM users WHERE id_user = '{idInfo}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                nameL.Text = reader[0].ToString();
                loginInput.Text = reader[0].ToString();
                passwordInput.Text = reader[4].ToString();
                dateRegistration.Text = reader[2].ToString();
                AppPage.isWorker = (bool)reader[3];

                string ifImage = "";
                if (ifImage != reader[1].ToString())
                {
                    System.Drawing.Image avatar = (Bitmap)((new ImageConverter()).ConvertFrom(reader[1]));
                    avatarPicture.Image = avatar;
                    avatarPicture.Invalidate();
                }
            }
            reader.Close();

            db.closeConnection();

            if (AppPage.idInfo !=idInfo)
            {
                guna2TabControl1.TabPages[1].Parent = null;
                avatarPicture.Cursor = Cursors.Default;
            }
            else if (AppPage.idInfo == idInfo)
            {
                sendMessageButton.Visible = false;
            }
            guna2Panel2.Invoke(addLoader, guna2Panel2, commentPanel);
            backgroundWorker1.RunWorkerAsync();
            searchUserInComment();
            if (youComment || AppPage.idInfo == idInfo)
            {
                commentButton.Visible = false;
            }
        }

        private void avatarPicture_Click(object sender, EventArgs e)
        {
            if (AppPage.idInfo == idInfo)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand($"UPDATE users SET image = @image WHERE id_user = '{idInfo}'", db.getConnection());

                db.openConnection();

                OpenFileDialog open_dialog = new OpenFileDialog();
                open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                if (open_dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        command.Parameters.AddWithValue("@image", File.ReadAllBytes($"{open_dialog.FileName}"));
                        command.ExecuteNonQuery();

                        Bitmap image = new Bitmap(open_dialog.FileName);
                        avatarPicture.Image = image;
                        avatarPicture.Invalidate();
                    }
                    catch
                    {
                        MessageBox.Show("Выбранное вами изображение больше 16 МБ, выберите другое", "Ошибка изображения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                db.closeConnection();
            }
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            AppPage.cab(AppPage.mb);
            of(new Messages(idInfo, of));
        }
        private void updateProfile()
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE users SET login=@login, password=@password Where id_user = @idU", db.getConnection());

            command.Parameters.AddWithValue("@login", loginInput.Text);
            command.Parameters.AddWithValue("@password", passwordInput.Text);
            command.Parameters.AddWithValue("@idU", AppPage.idInfo);

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                of(new Profile(idInfo, of));
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

            db.closeConnection();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            updateProfile();
        }

        private void commentButton_Click(object sender, EventArgs e)
        {
            AddComments ac = new AddComments(of, int.Parse(idInfo));
            of(ac);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            guna2Panel2.Invoke(addLoader, guna2Panel2, commentPanel);
            GenerateDynamicCommentControls();
            commentPanel.Invoke(viewPanel, commentPanel);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            guna2PictureBox1.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            new LoginPage().Show();
            AppPage.apppage.Close();
        }
    }
}
