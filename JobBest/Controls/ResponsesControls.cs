using JobBest.Classes;
using JobBest.Forms;
using JobBest.JobsForms;
using MySql.Data.MySqlClient;
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
    public partial class ResponsesControls : UserControl
    {
        AppPage.OpenForm of;
        private int _userID;
        private DateTime _dateCreate;
        private string _login;
        private Image _picture;
        private bool _isCreator;
        private int idJob;
        private string idExecutor = null;
        private ViewJobs.viewResponses responses;

        [Category("Custom Props")]
        public int userID
        {
            get { return _userID; }
            set
            { _userID = value; }
        }
        [Category("Custom Props")]
        public bool isCreator
        {
            get { return _isCreator; }
            set
            { _isCreator = value; }
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
        public ResponsesControls(AppPage.OpenForm of, int idJob, string idExecutors, ViewJobs.viewResponses responses)
        {
            InitializeComponent();
            this.of = of;
            this.idJob = idJob;
            if (idExecutors!="")
                this.idExecutor = idExecutors;
            this.responses = responses;
        }
        private void addExecutor()
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE jobs SET executor = @exec Where id_jobs = @idJ", db.getConnection());

            command.Parameters.AddWithValue("@exec", _userID);
            command.Parameters.AddWithValue("@idJ", idJob);

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                guna2Button1.Visible = false;
                checkMark.Visible = true;
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

            db.closeConnection();
        }

        private void avatarPicture_Click(object sender, EventArgs e)
        {
            of(new Profile(_userID.ToString(), of));
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {
            of(new Profile(_userID.ToString(), of));
        }

        private void ResponsesControls_Load(object sender, EventArgs e)
        {
            if (!isCreator)
            {
                guna2Button1.Visible = false;
            }

            if (idExecutor == "")
            {
                guna2Button1.Visible = true;
            }
            else
            {
                if (idExecutor != null)
                {
                    guna2Button1.Visible = false;
                    if (_userID == int.Parse(idExecutor))
                    {
                        checkMark.Visible = true;
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addExecutor();
            responses(_userID);
        }
    }
}
