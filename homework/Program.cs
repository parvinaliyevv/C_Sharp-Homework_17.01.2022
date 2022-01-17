using System;
using AdminNamespace;
using ClientNamespace;

namespace homework
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            User user = null;
            ConsoleKeyInfo key;

        respawn:
            user = null;

            Console.Clear();
            Menu();

            Console.Write("Enter your choice: ");
            key = Console.ReadKey();

            Console.Clear();

            try
            {
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    user = database.SignIn();
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    database.SignUpClient();
                    goto respawn;
                }
                else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                {
                    database.SignUpAdmin();
                    goto respawn;
                }
                else if (key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong Include!");
                    goto respawn;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            while (true)
            {
                Console.Clear();

                if (user is Admin admin)
                {
                    AdminMenu();

                    Console.Write("Enter your choice: ");
                    key = Console.ReadKey();
                    Console.Clear();

                    if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                    {
                        admin.NewPost();
                    }
                    else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                    {
                        admin.ShowNotifications();
                    }
                    else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                    {
                        admin.ShowPosts();
                    }
                    else if (key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4)
                    {
                        goto respawn;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Include!");
                        continue;
                    }
                }
                else if (user is Client client)
                {
                    ClientMenu();

                    Console.Write("Enter your choice: ");
                    key = Console.ReadKey();
                    Console.Clear();

                    try
                    {
                        if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                        {
                            database.ShowAllPost();
                        }
                        else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                        {
                            uint postID;

                            Console.Write("Include post ID: ");
                            postID = uint.Parse(Console.ReadLine());

                            var post = database.GetPost(postID);

                            if (post is null)
                            {
                                Console.WriteLine("Post with this id does not exist");
                                continue;
                            }

                            post.ViewCount++;
                            Console.WriteLine(post);

                            Console.WriteLine("Click 1 to like");
                            Console.WriteLine("Click 2 to continue\n");
                            key = Console.ReadKey();

                            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                            {
                                database.SendNotification(postID, client.Name);
                                post.LikeCount++;
                            }
                            else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2) continue;
                            else Console.WriteLine("Wrong Include!");
                        }
                        else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                        {
                            goto respawn;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Include!");
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else { goto respawn; }

                Console.ReadKey();
            }

            static void Menu()
            {
                Console.WriteLine("[1] - Sign In");
                Console.WriteLine("[2] - Sign Up User");
                Console.WriteLine("[3] - Sign Up Admin");
                Console.WriteLine("[4] - Exit\n");
            }

            static void AdminMenu()
            {
                Console.WriteLine("[1] - Add New Post");
                Console.WriteLine("[2] - Show Notifications");
                Console.WriteLine("[3] - Show My Posts");
                Console.WriteLine("[4] - Return Menu\n");
            }
            static void ClientMenu()
            {
                Console.WriteLine("[1] - Show All Posts");
                Console.WriteLine("[2] - Show Post");
                Console.WriteLine("[3] - Return Menu\n");
            }
        }
    }
}
