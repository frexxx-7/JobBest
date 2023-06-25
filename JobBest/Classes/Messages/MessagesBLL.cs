using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobBest.Classes.Messages
{
    internal class MessagesBLL
    {
        public bool SaveItemChats(int idUserOne, int idUserTwo)
        {
            try
            {
                DBFuncMessages objdal = new DBFuncMessages();
                return objdal.AddItemsToTableChat(idUserOne, idUserTwo);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        public bool SaveItemMessage(int chatId, int userId, string content)
        {
            try
            {
                DBFuncMessages objdal = new DBFuncMessages();
                return objdal.AddItemsToTableMessages(chatId, userId, content);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable GetItemsChats(int idUser)
        {
            try
            {
                DBFuncMessages objdal = new DBFuncMessages();
                return objdal.ReadItemsChats(idUser);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }

        public DataTable GetItemsMessages(int chatId, bool lastMessage)
        {
            try
            {
                DBFuncMessages objdal = new DBFuncMessages();
                return objdal.ReadItemsMessages(chatId, lastMessage);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}
