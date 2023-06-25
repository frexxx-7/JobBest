using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes
{
    internal class BLL
    {
        public bool SaveItemJobs(string title, string body, int budget, string dateFinish, bool isOrder, 
            string category, string keyWord, Image image, Image image_2, Image image_3, Image image_4, Image image_5)
        {
            try
            {
                DBFunc objdal = new DBFunc();
                return objdal.AddItemsToTableJobs(title, body, budget, dateFinish, isOrder, category, keyWord, image, image_2, image_3, image_4, image_5);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        public bool SaveItemVacancy(string format, string timetable, string special, string country)
        {
            try
            {
                DBFunc objdal = new DBFunc();
                return objdal.AddItemsToTableVacancy(format, timetable, special, country);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable GetItems(string table, string isOrder, double startRows, double numberRows, bool isAscending, 
            string category, string country, string budgetStart, string budgetEnd, string keyWord)
        {
            try
            {
                DBFunc objdal = new DBFunc();
                return objdal.ReadItemsTable(table, isOrder, startRows, numberRows, isAscending, category, country, budgetStart, budgetEnd, keyWord);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
        public DataTable GetYouItems(int idUSer, double startRows, double numberRows, string searchText)
        {
            try
            {
                DBFunc objdal = new DBFunc();
                return objdal.ReadYouItemsTable(idUSer, startRows, numberRows, searchText);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
        public DataTable GetYouItemsWork(int idUSer, double startRows, double numberRows, string searchText)
        {
            try
            {
                DBFunc objdal = new DBFunc();
                return objdal.ReadYouItemsTableWork(idUSer, startRows, numberRows, searchText);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}
