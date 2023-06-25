using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes
{
    
    internal class DBFunc
    {
        private int id_vacancy;
        public bool AddItemsToTableJobs(string title, string body, int budget, string dateFinish, bool isOrder, 
            string category, string keyWord, Image image, Image image_2, Image image_3, Image image_4, Image image_5)
        {
            DB db = new DB();
            if (isOrder == false)
            {
                string query1 = "SELECT id_vacancy FROM vacancy WHERE (id_vacancy = LAST_INSERT_ID())";
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query1, db.getConnection()))
                    {
                        db.openConnection();
                        id_vacancy = (int)cmd.ExecuteScalar();
                        db.closeConnection();
                    }
                }
                catch
                {
                    throw;
                }
            }

            string query = "INSERT INTO jobs(title, body, date, dateFinish, budget, id_user, isOrder, " +
                "category, keyWord, id_vacancy, image, image_2, image_3, image_4, image_5) " +
                "VALUES (@title, @body, @date, @dateFinish, @budget, @id_user, @isOrder, " +
                "@category, @keyWord, @id_vacancy, @image, @image_2, @image_3, @image_4, @image_5)";
            db.openConnection();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (title == null || body == null || budget == 0 || dateFinish==null)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@title", title.Trim());
                        cmd.Parameters.AddWithValue("@body", body.Trim());
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd.MM.yyyy"));
                        cmd.Parameters.AddWithValue("@dateFinish", dateFinish);
                        cmd.Parameters.AddWithValue("@budget", budget);
                        cmd.Parameters.AddWithValue("@id_user", int.Parse(AppPage.idInfo));
                        cmd.Parameters.AddWithValue("@isOrder", isOrder);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@keyWord", keyWord);
                        if (isOrder == false)
                        {
                            cmd.Parameters.AddWithValue("@id_vacancy", id_vacancy);
                        } else
                        {
                            cmd.Parameters.AddWithValue("@id_vacancy", null);
                        }
                        verifiImage(image, "image", cmd);
                        verifiImage(image_2, "image_2", cmd);
                        verifiImage(image_3, "image_3", cmd);
                        verifiImage(image_4, "image_4", cmd);
                        verifiImage(image_5, "image_5", cmd);
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

        private void verifiImage(Image image, string name, MySqlCommand cmd)
        {
            MemoryStream ms = new MemoryStream();
            if (image != null)
            {
                image.Save(ms, image.RawFormat);
            }
            cmd.Parameters.AddWithValue("@"+name, ms.Length != 0 ? ms.ToArray() : null);
        }

        public bool AddItemsToTableVacancy(string format, string timetable, string special, string country)
        {
            DB db = new DB();
            db.openConnection();
            string query = "INSERT INTO vacancy(format, timetable, special, country) VALUES (@format, @timetable, @special, @country)";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (format == null || timetable == null || special == null || country == null)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@format", format.Trim());
                        cmd.Parameters.AddWithValue("@timetable", timetable.Trim());
                        cmd.Parameters.AddWithValue("@special", special.Trim());
                        cmd.Parameters.AddWithValue("@country", country.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                db.closeConnection();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public DataTable ReadYouItemsTable(int idUSer, double startRows, double numberRows, string searchText)
        {
            DB db = new DB();

            db.openConnection();
            string query = searchText == null ?
                    $"SELECT * FROM jobs " +
                    $"WHERE id_user = {idUSer} "+
                    $"ORDER BY id_jobs DESC " +
                    $"LIMIT {startRows}, {numberRows};"
                    :
                    $"SELECT * FROM jobs " +
                    $"WHERE id_user = {idUSer} AND title LIKE '{searchText}%' " +
                    $"ORDER BY id_jobs DESC " +
                    $"LIMIT {startRows}, {numberRows};"
                    ;
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
        public DataTable ReadYouItemsTableWork(int idUSer, double startRows, double numberRows, string searchText)
        {
            DB db = new DB();

            db.openConnection();
            string query = searchText == null ?
                    $"SELECT * FROM jobs " +
                    $"WHERE executor = {idUSer} " +
                    $"ORDER BY id_jobs DESC " +
                    $"LIMIT {startRows}, {numberRows};"
                    :
                    $"SELECT * FROM jobs " +
                    $"WHERE executor = {idUSer} AND title LIKE '{searchText}%' " +
                    $"ORDER BY id_jobs DESC " +
                    $"LIMIT {startRows}, {numberRows};"
                    ;
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

        public DataTable ReadItemsTable(string table, string isOrder, double startRows, double numberRows, bool isAscending,
            string category, string country, string budgetStart, string budgetEnd, string keyWord)
        {
            string whereQuery = null;

            if (category!=null)
            {
                whereQuery = $"(category='{category}') AND ";
            }
            if (country!=null)
            {
                whereQuery += $"(country='{country}') AND ";
            }
            if (budgetStart != null)
            {
                whereQuery += $"(budget BETWEEN {budgetStart} AND {budgetEnd}) AND ";
            }
            if (keyWord !=null)
            {
                whereQuery += $"(keyWord='{keyWord}') AND ";
            }
            if (whereQuery!=null)
            {
                whereQuery = whereQuery.Remove(whereQuery.Length-5);
            }
            string query;
            DB db = new DB();

            db.openConnection();

            string sort = isAscending ? "ASC" : "DESC";
            if (category == null && country == null && budgetStart == null && keyWord == null)
            {
                query = isOrder != null ?
                    $"SELECT * FROM {table} " +
                    $"WHERE isOrder={isOrder} " +
                    $"ORDER BY id_jobs {sort} " +
                    $"LIMIT {startRows}, {numberRows};"
                    :
                    $"SELECT * FROM {table} " +
                    $"ORDER BY id_jobs {sort} " +
                    $"LIMIT {startRows}, {numberRows};";
            }
            else
            {
                query = isOrder != null ?
                    $"SELECT * FROM {table} " +
                    $"LEFT JOIN vacancy ON vacancy.id_vacancy = jobs.id_vacancy " +
                    $"WHERE isOrder={isOrder} AND {whereQuery}" +
                    $"ORDER BY id_jobs {sort} " +
                    $"LIMIT {startRows}, {numberRows};"
                    :
                    $"SELECT * FROM {table} " +
                    $"LEFT JOIN vacancy ON vacancy.id_vacancy = jobs.id_vacancy " +
                    $"WHERE {whereQuery} "+
                    $"ORDER BY id_jobs {sort} " +
                    $"LIMIT {startRows}, {numberRows};";
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
