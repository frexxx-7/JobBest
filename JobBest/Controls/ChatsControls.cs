using JobBest.JobsForms;
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
    public partial class ChatsControls : UserControl
    {
        private string _login;
        private Image _picture;
        private int _idChat;
        private string _lastMessageUser;
        private string _lastMessageContent;
        private DateTime _dateCreateLastMessage;
        private Messages.openPanel op;

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
            { _picture = value; }
        }
        [Category("Custom Props")]
        public int idChat
        {
            get { return _idChat; }
            set
            { _idChat = value; }
        }
        [Category("Custom Props")]
        public string LastMessageUser
        {
            get { return _lastMessageUser; }
            set
            { _lastMessageUser = value; lastMessageUserLabel.Text = _lastMessageUser; }
        }
        [Category("Custom Props")]
        public string LastMessageContent
        {
            get { return _lastMessageContent; }
            set
            { _lastMessageContent = value; lastMessageContentLabel.Text = _lastMessageContent; }
        }
        [Category("Custom Props")]
        public DateTime DateCreateLastMessage
        {
            get { return _dateCreateLastMessage; }
            set
            { _dateCreateLastMessage = value; dateLabel.Text = value.ToString("HH:mm dd.MM.yyyy"); }
        }
        public ChatsControls(Messages.openPanel del)
        {
            InitializeComponent();
            op = del;
        }

        private void ChatsControls_Load(object sender, EventArgs e)
        {
            if (_picture!=null)
            {
                avatarPicture.Image = _picture;
            }
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }

        private void avatarPicture_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }

        private void lastMessageContentLabel_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }

        private void lastMessageUserLabel_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }

        private void lastMessagePanel_Click(object sender, EventArgs e)
        {
            op(_picture, _login, _idChat.ToString());
        }
    }
}
