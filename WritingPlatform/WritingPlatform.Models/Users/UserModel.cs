﻿namespace WritingPlatform.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }
    }
}
