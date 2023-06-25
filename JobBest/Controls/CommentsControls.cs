using FontAwesome.Sharp;
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
    public partial class CommentsControls : UserControl
    {
        private string _login;
        private Image _picture;
        private int _idUser;
        private string _commentContent;
        private DateTime _dateCreateComment;
        private int _numberStar;
        private AppPage.OpenForm of;

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
        [Category("Custom Props")]
        public int idUser
        {
            get { return _idUser; }
            set
            { _idUser = value; }
        }
        
        [Category("Custom Props")]
        public string CommentContent
        {
            get { return _commentContent; }
            set
            { _commentContent = value; commentsContentLabel.Text = _commentContent; }
        }
        [Category("Custom Props")]
        public DateTime DateCreate
        {
            get { return _dateCreateComment; }
            set
            { _dateCreateComment = value; dateLabel.Text = value.ToString("HH:mm dd.MM.yyyy"); }
        }
        [Category("Custom Props")]
        public int NumberStar
        {
            get { return _numberStar; }
            set
            { _numberStar = value; }
        }
        public CommentsControls(AppPage.OpenForm of)
        {
            InitializeComponent();
            this.of= of;
        }

        private void CommentsControls_Load(object sender, EventArgs e)
        {
            foreach (Guna2Panel pn in this.Controls.OfType<Guna2Panel>())
            {
                foreach (Guna2Panel pn2 in pn.Controls.OfType<Guna2Panel>())
                {
                    int count = 1;
                    foreach (IconPictureBox ipb in pn2.Controls.OfType<IconPictureBox>().Reverse())
                    {
                        if (count <= _numberStar)
                        {
                            ipb.IconFont = IconFont.Solid;
                        }
                        else
                        {
                            ipb.IconFont = IconFont.Regular;
                        }
                        count++;
                    }
                }
            }
        }

        private void avatarPicture_Click(object sender, EventArgs e)
        {
            of(new Profile(idUser.ToString(), of));
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {
            of(new Profile(idUser.ToString(), of));
        }
    }
}
