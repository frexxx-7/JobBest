using JobBest.Classes;
using JobBest.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace JobBest
{
    public partial class LoginPage : Form
    {
        bool password = false;
        bool registerPassword = false;
        bool isWorker = false;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            errorText.Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            registrationPanel.Visible = true;
            labelRegistration.Visible = true;
            backButton.Visible = true;
            loginPanel.Visible = false;
            iconPicture.Visible = false;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            registrationPanel.Visible = false;
            labelRegistration.Visible = false;
            backButton.Visible = false;
            loginPanel.Visible = true;
            iconPicture.Visible = true;
            choicePanel.Visible = true;
            registerPanel.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            choicePanel.Visible = false;
            registerPanel.Visible = true;
            isWorker = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            choicePanel.Visible = false;
            registerPanel.Visible = true;
            isWorker = false;
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            choicePanel.Visible = true;
            registerPanel.Visible = false;
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            if (!registerPassword)
            {
                eyePicture.Image = System.Drawing.Image.FromFile("eye2.png");
                passwordInput.PasswordChar = '\0';
                repeatPassword.PasswordChar= '\0';
                registerPassword = true;
            } else
            {
                eyePicture.Image = System.Drawing.Image.FromFile("eye.png");
                passwordInput.PasswordChar = '*';
                repeatPassword.PasswordChar = '*';
                registerPassword = false;
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            string query = "SELECT * FROM users ORDER BY login";
            MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection());

            db.openConnection();

                if (LoginInput.Text == "" || passwordInput.Text == "" || repeatPassword.Text == "")
                {
                    errorLabel.Text = "Вы не ввели данные!";
                    errorLabel.Visible = true;
                }
                else
                {
                if (passwordInput.Text.Length >= 6)
                {
                    bool en = true;
                    bool symbol = false;
                    bool number = false;

                    for (int i = 0; i < passwordInput.Text.Length; i++)
                    {
                        if (passwordInput.Text[i] >= 'А' && passwordInput.Text[i] <= 'Я') en = false;
                        if (passwordInput.Text[i] >= '0' && passwordInput.Text[i] <= '9') number = true;
                        if (passwordInput.Text[i] == '_' || passwordInput.Text[i] == '-' || passwordInput.Text[i] == '!') symbol = true;
                    }
                    if (!en)
                    {
                        errorLabel.Text = "Доступна только английская раскладка";
                        errorLabel.Visible = true;
                    }
                    else if (!symbol)
                    {
                        errorLabel.Text = "Добавьте один из следующих символов: _, -, !";
                        errorLabel.Visible = true;
                    }
                    else if (!number)
                    {
                        errorLabel.Text = "Добавьте хотя бы одну цифру";
                        errorLabel.Visible = true;
                    }
                    if (en && symbol && number)
                    {
                        if (repeatPassword.Text == passwordInput.Text)
                        {
                            try
                            {
                                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                                {
                                    ApplyExecuteResults();

                                }
                            }
                            catch
                            {
                                errorLabel.Text = "Логин занят";
                                errorLabel.Visible = true;
                            }
                        }
                        else
                        {
                            errorLabel.Text = "Пароли не совпадают";
                            errorLabel.Visible = true;
                        }
                    }
                  
                }
                else 
                { 
                    errorLabel.Text = "Пароль слишком короткий, минимум 6 символов!";
                    errorLabel.Visible = true;
                }
            }
            db.closeConnection();
        }
        private void ApplyExecuteResults()
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `isWorker`, `dateRegistration`) VALUES (@login, @pass, @isWorker, @dateRegistration)", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginInput.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passwordInput.Text;
            command.Parameters.Add("@isWorker", MySqlDbType.Int64).Value = isWorker;
            command.Parameters.Add("@dateRegistration", MySqlDbType.String).Value = DateTime.Now.ToString("dd.MM.yyyy");

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                errorLabel.Text = "Аккаунт создан!";
                registrationPanel.Visible = false;
                loginPanel.Visible = true;
                iconPicture.Visible = true;
                backButton.Visible = false;
                labelRegistration.Visible = false;
                registerPanel.Visible = false;
                choicePanel.Visible = true;
            }
            else
            {
                errorLabel.Text = "Ошибка созадния аккаунта";
                errorLabel.Visible = true;
            }

            db.closeConnection();
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            if (!password)
            {
                eyePasswordAuth.Image = System.Drawing.Image.FromFile("eye2.png");
                PasswordTextBox.PasswordChar = '\0';
                password = true;
            }
            else
            {
                eyePasswordAuth.Image = System.Drawing.Image.FromFile("eye.png");
                PasswordTextBox.PasswordChar = '*';
                password = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string loginUser = LoginTextBox.Text;
            string passUser = PasswordTextBox.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                string queryAccount = $"SELECT id_user FROM users WHERE login = '{loginUser}'";
                MySqlCommand mySqlCommand = new MySqlCommand(queryAccount, db.getConnection());
                AppPage apppage = new AppPage();

                db.openConnection();

                AppPage.idInfo = mySqlCommand.ExecuteScalar().ToString();
                AppPage.isWorker = isWorker;

                db.closeConnection();

                errorText.Text = "Добро пожаловать ";
                errorText.Visible = true;
                apppage.isAdmin = loginUser;

                this.Hide();
                apppage.Show();
            }
            else
            {
                errorText.Text = "Неправильный логин или пароль";
                errorText.Visible = true;
            }
        }

        private void passwordInput_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible= false;
        }

        private void LoginInput_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
        }

        private void repeatPassword_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            errorText.Visible = false;
        }

        private void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
