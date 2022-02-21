using Common;
using DataAccess.Interfaces;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            //Dictionary<string, object> u = new Dictionary<string, object>
            //{
            //    { "firstName", user.FirstName },
            //    { "lastName", user.LastName },
            //    { "profilePic", user.ProfilePicUrl }
            //};
            await docRef.SetAsync(user);
        }

        public void DeleteUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Message>> GetMessages(string email)
        {
            // users >> ryanattard@gmail.com >> messages 

            if ((await GetUser(email)) == null) return new List<Message>(); //if user does not exist return an empty list

            Query messageQuery = db.Collection("users").Document(email).Collection("messages");
            QuerySnapshot messageQuerySnapshot = await messageQuery.GetSnapshotAsync();
            
            List<Message> messages = new List<Message>();

             
            foreach (DocumentSnapshot documentSnapshot in messageQuerySnapshot.Documents)
            {
                messages.Add(documentSnapshot.ConvertTo<Message>());
            }

            return messages;

        }

        public async Task<WriteResult> SendMessage(string email, Message msg)
        {
            DocumentReference docRef = db.Collection("users").Document(email).Collection("messages").Document(msg.Id);
            
            return await docRef.SetAsync(msg);

        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string email)
        {
            DocumentReference docRef = db.Collection("users").Document(email);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                //Console.WriteLine("Document data for {0} document:", snapshot.Id);
                //Dictionary<string, object> city = snapshot.ToDictionary();
                //foreach (KeyValuePair<string, object> pair in city)
                //{
                //    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                //}

                User myUser = snapshot.ConvertTo<User>();
                return myUser;
            }
            else
            {
                return null; 
            }
        }
    }
}
