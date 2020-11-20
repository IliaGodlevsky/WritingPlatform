using System;

namespace WritingPlatform.Models.Users
{
    public class NewUserModel
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
