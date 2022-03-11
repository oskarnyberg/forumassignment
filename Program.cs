using ForumAssignment.Models;
using ForumAssignment.Repos;
using Microsoft.Data.Sqlite;
using System;

namespace ForumAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                MenuSelection();
            }
        }

        static void MenuSelection()
        {
            Console.Clear();
            Console.WriteLine("----FOOD FORUM----");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Choose what to do by writing the number:\n");
            Console.WriteLine("1): List all threads");
            Console.WriteLine("2): Create a new thread");
            Console.WriteLine("0): End program");
            switch (Console.ReadLine())
            {
                case "1":
                    ListThreads();
                    break;
                case "2":
                    CreateThread();
                    break;
                case "0":
                    Console.WriteLine("Ending program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be an valid menu selection!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static void ListThreads()
        {
            var threads = ThreadRepository.ListThreads();
            Console.Clear();
            Console.WriteLine("Showing all threads in the forum");
            //int index = 1;
            for(int indx=1; indx<threads.Count+1; indx++)
                //foreach (var thread in threads)
            {
                var thread = threads[indx-1];
                //var posts = PostRepository.ListPosts(thread);
                Console.WriteLine($"[{indx}]");
                Console.WriteLine($"Topic: {thread.Topic}");
                Console.WriteLine($"Text: {thread.Text}");
                Console.WriteLine($"Author: {thread.Author}");
                Console.WriteLine($"Posts: {thread.PostCount}");
                //Console.WriteLine($"tread id : {thread.ThreadId}");
                Console.WriteLine("---------------------------------");
                //index++;
            }
            Console.WriteLine("Enter the number corresponding to the thread you want to enter, or 0 to go back");

            //var input = int.TryParse(Console.ReadLine(), out int choice);
            //switch (input)
            //{
            //    case "0":
            //        MenuSelection();
            //        break;
            //    default:
            //        if(input == threads[choice - 1])
            //        {

            //        }
            //        else
            //        {
            //            Console.WriteLine("Bad input");
            //        }
            //        break;
            //}


            var choice = int.TryParse(Console.ReadLine(), out int input);
            if (input == 0)
            {
                MenuSelection();
            }
            else
            {
                ListPosts(threads[input - 1]);
            }
            //var tempThread = new Thread();
            //bool checkInput = true;
            //while(checkInput == true)
            //{
            //    foreach (var thread in threads)
            //    {
            //        if (input == 0)
            //        {
            //            MenuSelection();
            //            checkInput = false;
            //        }
            //        else if (input == index)
            //        {
            //            tempThread = thread;
            //            checkInput = false;
            //        }
            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.WriteLine("Must be an valid menu selection!\n");
            //            Console.ForegroundColor = ConsoleColor.White;
            //        }
            //        index++;
            //    }
            //}
            //OpenThread(threads[input - 1]);
            //ListPosts(threads[input - 1]);

        }

        //static void OpenThread(Thread thread)
        //{
        //    Console.Clear();
        //    ThreadRepository.OpenThread(thread);
        //    Console.WriteLine($"Topic: {thread.Topic}");
        //    Console.WriteLine($"Text: {thread.Text}");
        //    Console.WriteLine($"Author: {thread.Author}");
        //    Console.WriteLine("---------------------------------");
        //    var posts = PostRepository.ListPosts(thread);
        //    foreach (var post in posts)
        //    {
        //        Console.WriteLine($"Text: {post.Text}");
        //        Console.WriteLine($"Author: {post.Author}");
        //        Console.WriteLine("---------------------------------");
        //    }
        //    bool choice = true;
        //    while (choice == true)
        //    {
        //        Console.WriteLine("What would you like to do on this thread? Enter corresponding number:\n");
        //        Console.WriteLine("1) Write a new post");
        //        Console.WriteLine("2) Edit or delete a post");
        //        Console.WriteLine("0) Go back to all threads");
        //        switch (Console.ReadLine())
        //        {
        //            case "1":
        //                CreatePost(thread);
        //                break;
        //            case "2":
        //                SelectPost(thread);
        //                break;
        //            case "0":
        //                Console.Clear();
        //                ListThreads();
        //                break;
        //            default:
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("Must be an valid menu selection!\n");
        //                Console.ForegroundColor = ConsoleColor.White;
        //                break;
        //        }
        //    }

        //    //var tempThread = ThreadRepository.GetThreadByThreadId(thread);
        //    //Console.WriteLine($"Topic: {thread.Topic}");
        //    //Console.WriteLine($"Text: {thread.Text}");
        //    //Console.WriteLine($"Author: {thread.Author}");
        //    //Console.WriteLine("---------------------------------");
        //    //ListPosts(tempThread);

        //}


        static void ListPosts(Thread thread)
        {
            Console.Clear();
            Console.WriteLine($"Topic: {thread.Topic}");
            Console.WriteLine($"Text: {thread.Text}");
            Console.WriteLine($"Author: {thread.Author}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");

            var posts = PostRepository.ListPosts(thread);
            foreach (var post in posts)
            {
                Console.WriteLine($"Text: {post.Text}");
                Console.WriteLine($"Author: {post.Author}");
                Console.WriteLine("---------------------------------");
            }

            bool choice = true;
            while (choice == true)
            {
                Console.WriteLine("What would you like to do on this thread? Enter corresponding number:\n");
                Console.WriteLine("1) Write a new post");
                Console.WriteLine("2) Edit or delete a post");
                Console.WriteLine("0) Go back to all threads");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreatePost(thread);
                        break;
                    case "2":
                        SelectPost(thread);
                        break;
                    case "0":
                        Console.Clear();
                        ListThreads();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Must be an valid menu selection!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                //int.TryParse(Console.ReadLine(), out int input);
                //if (input == 1)
                //{
                //    CreatePost(thread);
                //}
                //else if (input == 2)
                //{
                //    ListThreads();
                //}
                //else
                //{
                //    Console.WriteLine("Write 1 or 2");
                //}
            }


        }

        static void CreatePost(Thread thread)
        {
            Console.WriteLine("----Create a new post----");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Enter your username:\n");
            string userName = Console.ReadLine();
            Console.WriteLine("Write your post:\n");
            string text = Console.ReadLine();
            var tempPost = new Post();
            tempPost.Author = userName;
            tempPost.Text = text;
            tempPost.ThreadId = thread.ThreadId;
            //Console.WriteLine(tempPost.ThreadId);
            PostRepository.CreatePost(tempPost);
            Console.WriteLine("New post created");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            //OpenThread(thread);
            ListPosts(thread);
            //MenuSelection();
        }

        static void SelectPost(Thread thread)
        {
            Console.Clear();
            Console.WriteLine("Which post would you like to update?");
            var posts = PostRepository.ListPosts(thread);
            for (int indx = 1; indx < posts.Count + 1; indx++)
            {
                var post = posts[indx - 1];
                Console.WriteLine($"[{indx}]");
                Console.WriteLine($"Text: {post.Text}");
                Console.WriteLine($"Author: {post.Author}");
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("Enter the number corresponding to the post you want to select, or 0 to go back");
            var choice = int.TryParse(Console.ReadLine(), out int input);
            if (input == 0)
            {
                //OpenThread(thread);
                ListPosts(thread);
            }
            else
            {
                Console.WriteLine("1) Update post");
                Console.WriteLine("2) Delete post");
                Console.WriteLine("0) Go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        UpdatePost(posts[input -1]);
                        break;
                    case "2":
                        DeletePost(posts[input -1]);
                        break;
                    case "0":
                        Console.Clear();
                        //OpenThread(thread);
                        ListPosts(thread);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Must be an valid menu selection!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        static void UpdatePost(Post post)
        {
            Console.WriteLine($"Text: {post.Text}");
            Console.WriteLine($"Author: {post.Author}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Write the new text for the post \n");
            var tempPost = new Post();
            var newText = Console.ReadLine();
            tempPost.Text = newText;
            tempPost.PostId = post.PostId;
            //Console.WriteLine(tempPost.PostId);
            PostRepository.UpdatePost(tempPost);
            Console.Clear();
            Console.WriteLine("Post updated!!");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            var tempThread = new Thread();
            tempThread.ThreadId = post.ThreadId;
            //OpenThread(tempThread);
            ListPosts(tempThread);
        }

        static void DeletePost(Post post)
        {
            var tempThread = new Thread();
            tempThread.ThreadId = post.ThreadId;
            PostRepository.DeletePost(post);
            Console.Clear();
            Console.WriteLine("Post deleted!!");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            //OpenThread(tempThread);
            ListPosts(tempThread);
        }

        static void CreateThread()
        {
            Console.Clear();
            Console.WriteLine("----Create a new thread----");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Enter your username:\n");
            string userName = Console.ReadLine();
            Console.WriteLine("Write your threadtopic:\n");
            string topic = Console.ReadLine();
            Console.WriteLine("Write your thread:\n");
            string threadText = Console.ReadLine();
            var tempThread = new Thread();
            tempThread.Author = userName;
            tempThread.Topic = topic;
            tempThread.Text = threadText;
            ThreadRepository.CreateNewThread(tempThread);
            Console.WriteLine("New thread created");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            MenuSelection();
        }
    }
}
