using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IFireStoreDataAccess
    {
        Task<User> GetUser(string email);
        void AddUser(User user);
        void UpdateUser(User user);

        void SendMessage(string email, Message msg);

        List<Message> GetMessages(string email);
        void DeleteUser(string email);

    }
}
