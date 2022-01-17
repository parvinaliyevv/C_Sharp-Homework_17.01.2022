using System;
using PostNamespace;
using NotificationNamespace;

namespace AdminNamespace
{
    internal class Admin : homework.User
    {
        private static uint _id = default;

        private Post[] _posts = new Post[0];
        private Notification[] _notifications = new Notification[0];

        public string Username { get; set; }


        public Admin(string username, string email, string password) : base(_id++, email, password) => Username = username;


        public void NewPost()
        {
            Console.Write("Include Post Content: ");
            AppendPost(new Post(Console.ReadLine()));
        }

        public void ShowPosts()
        {
            if (_posts.Length == 0)
            {
                Console.WriteLine("Empty!");
                return;
            }

            foreach (var item in _posts)
            {
                Console.WriteLine(item);
            }
        }

        public void AppendPost(Post post)
        {
            if (post is null) throw new ArgumentNullException(nameof(post));

            var newPosts = new Post[_posts.Length + 1];

            for (int i = 0; i < _posts.Length; i++)
            {
                newPosts[i] = _posts[i];
            }

            newPosts[_posts.Length] = post;
            _posts = newPosts;
        }

        public Post GetPost(uint id)
        {
            foreach (var item in _posts)
            {
                if (item.ID.Equals(id)) return item;
            }

            return null;
        }

        public void ShowNotifications()
        {
            if (_notifications.Length == 0)
            {
                Console.WriteLine("Empty!");
                return;
            } 

            foreach (var item in _notifications)
            {
                Console.WriteLine(item);
            }

            ClearNotifications();
        }

        public void AppendNotifications(Notification notification)
        {
            if (notification is null) throw new ArgumentNullException(nameof(notification));

            var newNotifications = new Notification[_notifications.Length + 1];

            for (int i = 0; i < _notifications.Length; i++)
            {
                newNotifications[i] = _notifications[i];
            }

            newNotifications[_notifications.Length] = notification;
            _notifications = newNotifications;
        }

        public void ClearNotifications() => _notifications = new Notification[0];

        public override string ToString()
        {
            return String.Format("Username: {0}\t | Mail: {1}", Username, Email);
        }
    }
}
