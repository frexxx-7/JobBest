using Guna.UI2.WinForms;
using JobBest.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Controls
{
    public partial class MessageControls : UserControl
    {
        private AppPage.OpenForm of;
        private int _userID;
        private string _content;
        private DateTime _dateCreate;
        private string _login;
        private Image _picture;
        public MessageControls(AppPage.OpenForm of)
        {
            InitializeComponent();
            this.of = of;
        }
        [Category("Custom Props")]
        public int userID
        {
            get { return _userID; }
            set
            { _userID = value; }
        }
        [Category("Custom Props")]
        public string Content
        {
            get { return _content; }
            set
            { _content = value; contentLabel.Text = value; }
        }
        [Category("Custom Props")]
        public DateTime dateCreate
        {
            get { return _dateCreate; }
            set
            { _dateCreate = value; dateLabel.Text = value.ToString("HH:mm dd.MM.yyyy"); }
        }
        [Category("Custom Props")]
        public string Login
        {
            get { return _login; }
            set
            { _login = value; nameLabel.Text = value; }
        }
        [Category("Custom Props")]
        public Image Picture
        {
            get { return _picture; }
            set
            { _picture = value; avatarPicture.Image = value; }
        }
        private void MessageControls_Load(object sender, EventArgs e)
        {
            if (userID == int.Parse(AppPage.idInfo))
            {
                messagePanel.Location = new Point(17,9);
                avatarPicture.Location = new Point(516,9);
            }
        }

        private void dateLabel_Click(object sender, EventArgs e)
        {
        }

        private void avatarPicture_Click(object sender, EventArgs e)
        {
            of(new Profile(_userID.ToString(), of));
        }
    }
}
