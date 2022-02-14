using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IFireStoreDataAccess
    {
        void AddUser(User user);
        void UpdateUser(User user);

        void SendMessage(string email, Message msg);

        List<Message> GetMessages(string email);
        void DeleteUser(string email);

    }
}
