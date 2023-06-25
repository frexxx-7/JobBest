using Guna.UI2.WinForms;
using JobBest.Classes;
using JobBest.Classes.Messages;
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
using System.Windows.Input;

namespace JobBest.JobsForms
{
    public partial class Messages : Form
    {
        private string login;
        private Image image;

        private delegate void addPanelControls(Guna2Panel panel, Guna2Panel parentPanel);
        private addPanelControls addControls;

        private delegate void viewPanelChats(Guna2Panel panel);
        private viewPanelChats viewPanel;

        public delegate void openPanel(Image img, string log, string idChat);
        private openPanel openMessagePanel;

        public delegate void clearPanel(Guna2Panel panel);
        private clearPanel clearControlsPanel;

        private delegate void addLoaderToPanel(Guna2Panel parentPanel, Guna2Panel panel);
        private addLoaderToPanel addLoader;

        private string idActiveChat = null;
        private int openUserID;
        private string idLastChat = null;

        AppPage.OpenForm of;
        public Messages(string idUser, AppPage.OpenForm of)
        {
            InitializeComponent();
            messageContentPanel.Visible = false;
            addControls = new addPanelControls(addControlsPanel);
            viewPanel = new viewPanelChats(viewPanels);
            openMessagePanel= new openPanel(openMPanel);
            clearControlsPanel = new clearPanel(clearVoidPanel);
            addLoader = new addLoaderToPanel(addedLoader);
            this.of = of;

            if (idUser!=null)
            {
                loadUserInfo(int.Parse(idUser));
                searchChat(idUser);
                openMPanel(image, login, idActiveChat);
                openUserID = int.Parse(idUser);

            }
        }
        private void addedLoader(Guna2Panel parentPanel, Guna2Panel panel)
        {
            parentPanel.Controls.Add(guna2PictureBox1);
            guna2PictureBox1.BringToFront();
            guna2PictureBox1.Dock = DockStyle.Fill;
            panel.Controls.Clear();
        }
        private void getIdCreateChat()
        {
            DB db = new DB();
            string queryInfo = $"SELECT max(id_chat) FROM chat";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                idLastChat = reader[0].ToString();
            }
            reader.Close();

            db.closeConnection();
        }
        private void clearVoidPanel(Guna2Panel panel)
        {
            PanelMessages.Controls.Clear();
        }
        private void searchChat(string idUser)
        {
            DB db = new DB();
            string queryInfo = $"SELECT id_chat FROM chat WHERE ((userOne_id = {AppPage.idInfo}) AND (userTwo_id = {idUser}) OR (userOne_id = {idUser}) AND (userTwo_id = {AppPage.idInfo}))";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                idActiveChat = reader[0].ToString();
            }
            reader.Close();

            db.closeConnection();
        }
        private void openMPanel(Image img, string log, string idChat)
        {
            if (idChat != null)
            {
                removeControlsPanel();
                messageContentPanel.Visible = true;
                nameLabel.Text = log;
                if (img != null)
                    avatarPicture.Image = img;
                idActiveChat = idChat;
                PanelMessages.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker2.RunWorkerAsync();
            } else 
            if(idChat == null)
            {
                messageContentPanel.Visible = true;
                nameLabel.Text = log;
                if (img != null)
                    avatarPicture.Image = img;
            }
        }
        private void removeControlsPanel()
        {
            PanelMessages.Controls.Clear();
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
        private void loadUserInfo(int userId)
        {
            DB db = new DB();
            string queryInfo = $"SELECT login, image, id_user FROM users WHERE id_user = '{userId}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                login = reader[0].ToString();
                openUserID = (int)reader[2];
                string ifImage = "";
                if (ifImage != reader[1].ToString())
                {
                    System.Drawing.Image avatar = (Bitmap)((new ImageConverter()).ConvertFrom(reader[1]));
                    image = avatar;
                }
            }
            reader.Close();

            db.closeConnection();
        }
        private void GenerateDynamicChatsControls()
        {
            MessagesBLL objbll = new MessagesBLL();

            DataTable dt = objbll.GetItemsChats(int.Parse(AppPage.idInfo));

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ChatsControls[] listItems = new ChatsControls[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"chatPanel+{panelNumber}",
                                Size = new Size(692, 100),
                                Location = new Point(0, 118 * panelNumber + 20),
                                //Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top ,
                                Dock = DockStyle.Top,
                            };
                            listItems[i] = new ChatsControls(openMessagePanel);
                            if (int.Parse(row["userOne_id"].ToString())!=int.Parse(AppPage.idInfo))
                            {
                                loadUserInfo(int.Parse(row["userOne_id"].ToString()));
                            }else if (int.Parse(row["userTwo_id"].ToString()) != int.Parse(AppPage.idInfo))
                            {
                                loadUserInfo(int.Parse(row["userTwo_id"].ToString()));
                            }
                            MessagesBLL objbll2 = new MessagesBLL();

                            DataTable dt2 = objbll2.GetItemsMessages((int)row["id_chat"], true);

                            if (dt2.Rows.Count > 0)
                            {
                                for (int j = 0; j < 1; j++)
                                {
                                    foreach (DataRow row2 in dt2.Rows)
                                    {
                                        if (int.Parse(AppPage.idInfo) == (int)row2["user_id"])
                                        {
                                            listItems[i].LastMessageUser = "Вы:";
                                        }
                                        else
                                        {
                                            listItems[i].LastMessageUser = row2["user_id"].ToString();
                                        }
                                        listItems[i].LastMessageContent = (string)row2["content"];
                                        listItems[i].DateCreateLastMessage = (DateTime)row2["date_create"];
                                    }
                                }
                            }
                            listItems[i].Login = login;
                            listItems[i].Picture = image;
                            listItems[i].idChat = int.Parse(row["id_chat"].ToString());
                            //if (usOne == true)
                            //    listItems[i].idUser = int.Parse(row["userTwo_id"].ToString());
                            //else
                            //    if (usOne==false)
                            //        listItems[i].idUser = int.Parse(row["userOne_id"].ToString());
                            
                            listItems[i].Dock = DockStyle.Top;

                            panel.Controls.Add(listItems[i]);
                            chatsPanel.Invoke(addControls, panel, chatsPanel);
                            panelNumber++;
                            //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }

                    }
                }
            }

        }
        private void GenerateDynamicMessagesControls(string idChat)
        {
            MessagesBLL objbll = new MessagesBLL();

            DataTable dt = objbll.GetItemsMessages(int.Parse(idChat), false);
            
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    MessageControls[] listItems = new MessageControls[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"chatPanel+{panelNumber}",
                                Size = new Size(692, 96),
                                Location = new Point(0, 118 * panelNumber + 20),
                                //Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top ,
                                Dock = DockStyle.Top,
                                Padding = new System.Windows.Forms.Padding(bottom:6, left:0, top:0, right:0),
                            };
                            listItems[i] = new MessageControls(of);
                            
                            listItems[i].userID = (int)row["user_id"];
                            listItems[i].Content = row["content"].ToString();
                            listItems[i].dateCreate = (DateTime)row["date_create"];
                            if (int.Parse(AppPage.idInfo) == (int)row["id_user"])
                            {
                                listItems[i].Login = "Вы";
                                listItems[i].Dock = DockStyle.Right;
                            }
                            else
                            {
                                listItems[i].Login = (string)row["login"];
                                listItems[i].Dock = DockStyle.Left;
                            }
                            if (row["image"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["image"]);
                                listItems[i].Picture = new Bitmap(ms);
                            }

                            panel.Controls.Add(listItems[i]);
                            PanelMessages.Invoke(addControls, panel, PanelMessages);
                            panelNumber++;
                            //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }

                    }
                }
            }

        }

        private void Messages_Load(object sender, EventArgs e)
        {
            guna2Panel1.Invoke(addLoader, guna2Panel1, chatsPanel);
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            guna2Panel1.Invoke(addLoader, guna2Panel1, chatsPanel);
            GenerateDynamicChatsControls();
            chatsPanel.Invoke(viewPanel, chatsPanel);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            guna2PictureBox1.Visible = false;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (messageContentPanel.InvokeRequired)
                messageContentPanel.Invoke(addLoader, messageContentPanel, PanelMessages);
            if (PanelMessages.InvokeRequired)
                PanelMessages.Invoke(clearControlsPanel, PanelMessages);
            GenerateDynamicMessagesControls(idActiveChat);
            if (PanelMessages.InvokeRequired)
                PanelMessages.Invoke(viewPanel, PanelMessages);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            guna2PictureBox1.Visible = false;
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            if (idActiveChat==null)
            {
                MessagesBLL objbll2 = new MessagesBLL();

                if (objbll2.SaveItemChats(int.Parse(AppPage.idInfo), openUserID))
                {
                    getIdCreateChat();
                    if (idLastChat!=null)
                        idActiveChat = idLastChat;
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            MessagesBLL objbll = new MessagesBLL();
                if (messageInput.Text.Length == 0)
                {
                    messageInput.PlaceholderForeColor= Color.Red;
                }
                else
                if (objbll.SaveItemMessage(int.Parse(idActiveChat), int.Parse(AppPage.idInfo), messageInput.Text))
                {
                messageInput.Text = "";
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            PanelMessages.Visible = false;
            guna2PictureBox1.Visible = true;
            backgroundWorker2.RunWorkerAsync();
        }

        private void messageInput_TextChanged(object sender, EventArgs e)
        {
            messageInput.PlaceholderForeColor = Color.FromArgb(102, 252, 241);
        }

        private void messageInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (idActiveChat == null)
                {
                    MessagesBLL objbll2 = new MessagesBLL();

                    if (objbll2.SaveItemChats(int.Parse(AppPage.idInfo), openUserID))
                    {
                        getIdCreateChat();
                        if (idLastChat != null)
                            idActiveChat = idLastChat;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
                MessagesBLL objbll = new MessagesBLL();
                if (messageInput.Text.Length == 0)
                {
                    messageInput.PlaceholderForeColor = Color.Red;
                }
                else
                if (objbll.SaveItemMessage(int.Parse(idActiveChat), int.Parse(AppPage.idInfo), messageInput.Text))
                {
                    messageInput.Text = "";
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
                PanelMessages.Visible = false;
                guna2PictureBox1.Visible = true;
                backgroundWorker2.RunWorkerAsync();
            }

        }

        private void avatarPicture_Click(object sender, EventArgs e)
        {
            of(new Profile(openUserID.ToString(), of));
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {
            of(new Profile(openUserID.ToString(), of));
        }
    }
}
