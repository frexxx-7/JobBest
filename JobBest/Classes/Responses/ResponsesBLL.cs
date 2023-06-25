using JobBest.Classes.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes.Responses
{
    internal class ResponsesBLL
    {
        public bool SaveItemResponse(int idJob, int idUSer)
        {
            try
            {
                DBFuncResponses objdal = new DBFuncResponses();
                return objdal.AddItemsToTableResponse(idJob, idUSer);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable GetItemsResponse(int idJob)
        {
            try
            {
                DBFuncResponses objdal = new DBFuncResponses();
                return objdal.ReadItemsRespose(idJob);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}
