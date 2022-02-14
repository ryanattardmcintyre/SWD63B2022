using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicUrl { get; set; }
    }

    public class Message
    {
        public string Id { get; set; }
        public string DateSet { get; set; }
        public string Recipient { get; set; }
        public string Text { get; set; }
    }
}
