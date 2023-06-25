using JobBest.Classes.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes.Comments
{
    internal class CommentsBLL
    {
        public bool SaveItemComment(int idCreator, int idUser, string content, int numberStar)
        {
            try
            {
                DBFuncComments objdal = new DBFuncComments();
                return objdal.AddItemsToTableComment(idCreator, idUser, content, numberStar);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable GetItemsComment(int idUser)
        {
            try
            {
                DBFuncComments objdal = new DBFuncComments();
                return objdal.ReadItemsComment(idUser);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}
