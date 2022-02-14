using Common;
using DataAccess.Interfaces;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class FireStoreDataAccess : IFireStoreDataAccess
    {
        private FirestoreDb db { get; set; }
        public FireStoreDataAccess(string project) //google project id
        {
              db = FirestoreDb.Create(project);
        }

        public async void AddUser(User user)
        {
            DocumentReference docRef = db.Collection("users").Document(user.Email);
            Dictionary<string, object> u = new Dictionary<string, object>
            {
                { "firstName", user.FirstName },
                { "lastName", user.LastName },
                { "profilePic", user.ProfilePicUrl }
            };
            await docRef.SetAsync(u);
        }

        public void DeleteUser(string email)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessages(string email)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string email, Message msg)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
