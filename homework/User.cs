using System;

namespace homework
{
    internal abstract class User
    {
        public uint ID { get; init; }

        public string Email { get; set; }
        public string Password { get; set; }

        protected User(uint ID, string email, string password)
        {
            this.ID = ID;
            this.Email = email;
            this.Password = password;
        }

    }
}
