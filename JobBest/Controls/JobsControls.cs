using FontAwesome.Sharp;
using JobBest.Classes;
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
    public partial class JobsControls : UserControl
    {
        AppPage.OpenForm of;
        private string numberResponses;
        private void countResponses()
        {
            DB db = new DB();
            string queryInfo = $"SELECT count(*) FROM responses WHERE (id_job = {_id_jobs})";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (!reader.HasRows)
            {
                numberResponses = "0";
            }

            while (reader.Read())
            {
                if (reader[0].ToString() != "")
                    numberResponses = reader[0].ToString();
            }

            reader.Close();

            db.closeConnection();
        }

        public JobsControls(AppPage.OpenForm OpenChildForm)
        {
            InitializeComponent();
            of = OpenChildForm;
        }

        private string _head;
        private string _body;
        private string _date;
        private int _budget;
        private int _id_jobs;
        private Image _picture;
        private bool _isOrder;

        [Category("Custom Props")]
        public Image Picture
        {
            get { return _picture; }
            set
            { _picture = value; coverPicture.Image = value; }
        }

        [Category("Custom Props")]
        public string Head
        {
            get { return _head; }
            set
            { _head = value; headLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string Body
        {
            get { return _body; }
            set
            { _body = value; bodyLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string Date
        {
            get { return _date; }
            set
            { _date = value; dateLabel.Text = value; }
        }

        [Category("Custom Props")]
        public int Budget
        {
            get { return _budget; }
            set
            { _budget = value; budgetLabel.Text = value.ToString()+" BYN"; }
        }
        [Category("Custom Props")]
        public int id_jobs
        {
            get { return _id_jobs; }
            set
            { _id_jobs = value; }
        }
        [Category("Custom Props")]
        public bool isOrder
        {
            get { return _isOrder; }
            set
            { _isOrder = value; }
        }

        private void mouseMove()
        {
            bodyLabel.ForeColor = Color.FromArgb(197, 198, 199);
            headLabel.ForeColor = Color.FromArgb(197, 198, 199);
            budgetLabel.ForeColor = Color.FromArgb(197, 198, 199);
            dateLabel.ForeColor = Color.FromArgb(197, 198, 199);
            ResponsesLabel.ForeColor = Color.FromArgb(197, 198, 199);
        }
        private void mouseLeave()
        {
            bodyLabel.ForeColor = Color.FromArgb(102, 252, 241);
            headLabel.ForeColor = Color.FromArgb(102, 252, 241);
            budgetLabel.ForeColor = Color.FromArgb(102, 252, 241);
            dateLabel.ForeColor = Color.FromArgb(102, 252, 241);
            ResponsesLabel.ForeColor = Color.FromArgb(102, 252, 241);
        }
        private void click()
        {
            of(new ViewJobs(of, _id_jobs));
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void guna2Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void budgetLabel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void dateLabel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void guna2Panel2_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void budgetLabel_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void dateLabel_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            click();
        }

        private void guna2Panel2_Click(object sender, EventArgs e)
        {
            click();
        }

        private void budgetLabel_Click(object sender, EventArgs e)
        {
            click();
        }

        private void dateLabel_Click(object sender, EventArgs e)
        {
            click();
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void flowLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            click();
        }

        private void headLabel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void headLabel_Click(object sender, EventArgs e)
        {
            click();
        }

        private void headLabel_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void bodyLabel_Click(object sender, EventArgs e)
        {
            click();
        }

        private void bodyLabel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void bodyLabel_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void JobsControls_Load(object sender, EventArgs e)
        {
            if (isOrder == true || _picture==null)
            {
                coverPicture.Visible = false;
                guna2Panel2.Location = new Point(16, 16);
            }
            countResponses();
            ResponsesLabel.Text = "Откликов: "+ numberResponses.ToString();
        }

        private void coverPicture_Click(object sender, EventArgs e)
        {
            click();
        }

        private void coverPicture_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void coverPicture_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }

        private void ResponsesLabel_Click(object sender, EventArgs e)
        {
            click();
        }

        private void ResponsesLabel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void ResponsesLabel_MouseLeave(object sender, EventArgs e)
        {
            mouseLeave();
        }
    }
}
