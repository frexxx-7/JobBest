using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes.Responses
{
    internal class DBFuncResponses
    {
        public bool AddItemsToTableResponse(int idJob, int idUser)
        {
            DB db = new DB();

            string query = "INSERT INTO responses(id_job, id_user) " +
                "VALUES (@id_job, @id_user)";
            db.openConnection();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (idJob == 0 || idUser == 0)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@id_job", idJob);
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

        public DataTable ReadItemsRespose(int idJob)
        {
            DB db = new DB();

            db.openConnection();
            string query = $"SELECT * FROM responses " +
                    $"LEFT JOIN users ON users.id_user = responses.id_user " +
                    $"WHERE (id_job = {idJob}) " +
                    $"ORDER BY id_job ASC ";
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
