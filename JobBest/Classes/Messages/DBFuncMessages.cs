using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes.Messages
{
    internal class DBFuncMessages
    {
        public bool AddItemsToTableChat(int userIdOne, int userIdTwo)
        {
            DB db = new DB();

            string query = "INSERT INTO chat(userOne_id, userTwo_id) " +
                "VALUES (@userOne_id, @userTwo_id)";
            db.openConnection();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (userIdOne == 0 || userIdTwo == 0)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@userOne_id", userIdOne);
                        cmd.Parameters.AddWithValue("@userTwo_id", userIdTwo);
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

        public bool AddItemsToTableMessages(int chatId, int userId, string content)
        {
            DB db = new DB();

            string query = "INSERT INTO messages(chat_id, user_id, content) " +
                "VALUES (@chat_id, @user_id, @content)";
            db.openConnection();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (chatId == 0 || userId == 0 || content == null)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@chat_id", chatId);
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@content", content);
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

        public DataTable ReadItemsChats(int idUser)
        {
            DB db = new DB();

            db.openConnection();
            string query = $"SELECT * FROM chat " +
                    $"WHERE (userOne_id = {idUser}) OR  (userTwo_id = {idUser}) " +
                    $"ORDER BY id_chat DESC ";
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

        public DataTable ReadItemsMessages(int chatId, bool lastMessage)
        {
            DB db = new DB();

            db.openConnection();
            string query = null;
            if (lastMessage)
            {
                query = $"SELECT * FROM messages " +
                        $"WHERE (chat_id = {chatId}) " +
                        $"ORDER BY date_create DESC "+
                        $"LIMIT 1";
            }
            else if (!lastMessage)
            {
                query = $"SELECT * FROM messages " +
                        $"LEFT JOIN users ON users.id_user = messages.user_id " +
                        $"WHERE (chat_id = {chatId}) " +
                        $"ORDER BY date_create ASC ";
            }
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
