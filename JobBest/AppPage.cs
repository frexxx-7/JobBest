using FontAwesome.Sharp;
using JobBest.Forms;
using JobBest.JobsForms;
using JobBest.PageForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace JobBest
{
    public partial class AppPage : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public string isAdmin;
        public static string idInfo;
        public static bool isWorker;

        public delegate void OpenForm(Form childForm);
        public delegate void changeActiveButton(object senderBtn);
        public static changeActiveButton cab;

        public static IconButton mb => apppage.chatsButton;
        public static AppPage apppage;

        public AppPage()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 45);
            panelMenu.Controls.Add(leftBorderBtn);
            this.ControlBox = false;
            this.DoubleBuffered= true;
            ActiveButton(ProfileButton);
            this.Size = new Size(1400,800);
            cab = new changeActiveButton(ActiveButton);
            apppage = this;
        }

        private void ActiveButton (object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(31, 40, 51);
                currentBtn.ForeColor = Color.FromArgb(102, 252, 241);
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.FromArgb(102, 252, 241);
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = Color.FromArgb(102, 252, 241);
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = Color.FromArgb(102, 252, 241);
            }
        }

        private void DisableButton()
        {
            if (currentBtn!=null)
            {
                currentBtn.BackColor = Color.FromArgb(11, 12, 16);
                currentBtn.ForeColor = Color.FromArgb(102, 252, 241);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(102, 252, 241);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                    currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitleChildForm.Text = currentBtn.Text;
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            OpenForm of = new OpenForm(OpenChildForm);
            Profile profile= new Profile(idInfo, of);
            ActiveButton(sender);
            OpenChildForm(profile);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenForm of = new OpenForm(OpenChildForm);
            ActiveButton(sender);
            OpenChildForm(new Lenta(of));
        }

        private void AppPage_Load(object sender, EventArgs e)
        {
            OpenForm of = new OpenForm(OpenChildForm);
            Profile profile = new Profile(idInfo, of);
            OpenChildForm(profile);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenForm of = new OpenForm(OpenChildForm);
            ActiveButton(sender);
            OpenChildForm(new YouJobs(of));
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            OpenForm of = new OpenForm(OpenChildForm);
            Messages messages = new Messages(null, of);
            ActiveButton(sender);
            OpenChildForm(messages);
        }
    }
}
