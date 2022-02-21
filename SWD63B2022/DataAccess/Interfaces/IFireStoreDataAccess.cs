using Common;
using Google.Cloud.Firestore;
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

        Task<WriteResult> SendMessage(string email, Message msg);

        Task<List<Message>> GetMessages(string email);
        void DeleteUser(string email);

    }
}
