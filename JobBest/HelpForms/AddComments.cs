using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using JobBest.Classes;
using JobBest.Classes.Comments;
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

namespace JobBest.HelpForms
{
    public partial class AddComments : Form
    {
        private AppPage.OpenForm of;
        private int numberStar = 1;
        private int idUser;
        public AddComments(AppPage.OpenForm of, int idUSer)
        {
            InitializeComponent();
            this.of = of;
            this.idUser= idUSer;
        }
        private void fillStars()
        {
            foreach (Guna2Panel pn in this.Controls.OfType<Guna2Panel>())
            {
                int count = 1;
                foreach (IconPictureBox ipb in pn.Controls.OfType<IconPictureBox>().Reverse())
                {
                    if (count<=numberStar)
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
        private void starIcon1_Click(object sender, EventArgs e)
        {
            numberStar = 1;
            fillStars();
        }

        private void starIcon2_Click(object sender, EventArgs e)
        {
            numberStar = 2;
            fillStars();
        }

        private void starIcon3_Click(object sender, EventArgs e)
        {
            numberStar = 3;
            fillStars();
        }

        private void starIcon4_Click(object sender, EventArgs e)
        {
            numberStar = 4;
            fillStars();
        }

        private void starIcon5_Click(object sender, EventArgs e)
        {
            numberStar = 5;
            fillStars();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            CommentsBLL objbll = new CommentsBLL();

                if (bodyInput.Text.Length == 0)
                {
                    bodyInput.PlaceholderForeColor= Color.Red;
                }
                else
                if (objbll.SaveItemComment(int.Parse(AppPage.idInfo), idUser, bodyInput.Text, numberStar))
                {
                    Profile pr = new Profile(idUser.ToString(), of);
                    of(pr);
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }

        private void bodyInput_TextChanged(object sender, EventArgs e)
        {
            bodyInput.PlaceholderForeColor = Color.FromArgb(102, 252, 241);
        }
    }
}
