using System;
using ClientNamespace;
using AdminNamespace;
using PostNamespace;

namespace homework
{
    internal class Database
    {
        private User[] _users = new User[0];

        public void SignUpClient()
        {
            string name, surname, email, password;
            byte age;

            Console.Write("Include your Name: ");
            name = Console.ReadLine();

            Console.Write("Include your Surname: ");
            surname = Console.ReadLine();

            Console.Write("Include your Age: ");
            age = byte.Parse(Console.ReadLine());

        retry:

            Console.Write("Include your email: ");
            email = Console.ReadLine();

            if (Find(email) is not null)
            {
                Console.WriteLine("This email is already in use!");
                goto retry;
            }

            Console.Write("Include your password: ");
            password = Console.ReadLine();

            Append(new Client(name, surname, age, email, Hash.HashString(password)));
        }

        public void SignUpAdmin()
        {
            string username, email, password;

            Console.Write("Include your Username: ");
            username = Console.ReadLine();

        retry:

            Console.Write("Include your Email: ");
            email = Console.ReadLine();

            if (Find(email) is not null)
            {
                Console.WriteLine("This email is already in use!");
                goto retry;
            }

            Console.Write("Include your Password: ");
            password = Console.ReadLine();

            Append(new Admin(username, email, Hash.HashString(password)));
        }

        public User SignIn()
        {
            string email, password;

            Console.Write("Include account Email: ");
            email = Console.ReadLine();

            Console.Write("Include account Password: ");
            password = Console.ReadLine();

            var user = Find(email);

            if (user is null) throw new Exception("Account with this email does not exist");
            else
            {
                if (user.Password == Hash.HashString(password)) return user;
                else throw new Exception("Wrong account Password!");
            }
        }

        public void ShowAllPost()
        {
            if (_users.Length == 0)
            {
                Console.WriteLine("Empty!");
                return;
            }

            foreach (var item in _users)
            {
                if (item is Admin admin)
                {
                    admin.ShowPosts();
                }
            }
        }

        public void SendNotification(uint id, string userName)
        {
            foreach (var item in _users)
            {
                if (item is Admin admin)
                {
                    var data = admin.GetPost(id);

                    if (data is not null)
                    {
                        admin.AppendNotifications(new NotificationNamespace.Notification($"Post with this {id} liked", userName));
                        return;
                    }
                }
            }

            throw new ArgumentException(nameof(id), "Post with this id does not exist!");
        }

        public Post GetPost(uint id)
        {
            foreach (var item in _users)
            {
                if (item is Admin admin)
                {
                    var data = admin.GetPost(id);

                    if (data is not null) return data;
                }
            }

            return null;
        }

        private void Append(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            var newUsers = new User[_users.Length + 1];

            for (int i = 0; i < _users.Length; i++)
            {
                newUsers[i] = _users[i];
            }

            newUsers[_users.Length] = user;
            _users = newUsers;
        }

        private User Find(string email)
        {
            foreach (var item in _users)
            {
                if (item.Email == email) return item;
            }

            return null;
        }
    }
}
