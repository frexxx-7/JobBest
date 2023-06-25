using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes.Comments
{
    internal class DBFuncComments
    {
        public bool AddItemsToTableComment(int idCreator, int idUser, string content, int numberStar)
        {
            DB db = new DB();

            string query = "INSERT INTO comments(id_userCreator, content, numberStars, id_userComment) " +
                "VALUES (@id_creator, @content, @numberStar, @id_user)";
            db.openConnection();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (idCreator == 0 || idUser == 0 || content ==null || numberStar == 0)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@id_creator", idCreator);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.Parameters.AddWithValue("@numberStar", numberStar);
                        cmd.Parameters.AddWithValue("@id_user", idUser);
                        cmd.ExecuteNonQuery();
                        db.closeConnection();
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public DataTable ReadItemsComment(int idUser)
        {
            DB db = new DB();

            db.openConnection();
            string query = $"SELECT * FROM comments " +
                    $"LEFT JOIN users ON users.id_user = comments.id_userCreator " +
                    $"WHERE (id_userComment = {idUser}) " +
                    $"ORDER BY date_create DESC ";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
            try
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
