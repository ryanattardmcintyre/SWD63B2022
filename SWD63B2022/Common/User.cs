using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public string FirstName { get; set; }

        [FirestoreProperty]
        public string LastName { get; set; }

        [FirestoreProperty]
        public string ProfilePicUrl { get; set; }
    }
    [FirestoreData]
    public class Message
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string DateSet { get; set; }
        [FirestoreProperty]
        public string Recipient { get; set; }
        [FirestoreProperty]
        public string Text { get; set; }
    }
}
