using System;

namespace ClientNamespace
{
    internal class Client : homework.User
    {
        private static uint _id = default;

        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }

        public Client(string name, string surname, byte age, string email, string password) : base(_id++, email, password)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}\n Surname: {1}\n Age: {2}", Name, Surname, Age);
        }
    }
}
