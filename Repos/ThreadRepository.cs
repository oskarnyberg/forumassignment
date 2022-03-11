using Dapper;
using ForumAssignment.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumAssignment.Repos
{
    public class ThreadRepository
    {
        private const string connectionString = "Data Source =.\\database.db";

        public static List<Thread> ListThreads()
        {
            using var connection = new SqliteConnection(connectionString);
            //var data = connection.Query<Thread>("SELECT * FROM Threads");
            var data = connection.Query<Thread>($"SELECT Threads.Topic, Threads.Author, Threads.Text, COUNT(PostId) AS PostCount FROM Threads LEFT OUTER JOIN Posts ON Threads.ThreadId=Posts.ThreadId GROUP BY Threads.ThreadId");
            return data.ToList();
        }

        public static Thread GetThreadByThreadId(Thread thread)
        {
            using var connection = new SqliteConnection(connectionString);
            var sqlQuery = connection.Query<Thread>($"SELECT * FROM Threads WHERE ThreadId = {thread.ThreadId}");
            return thread;
        }
        //public static List<Thread> OpenThread(Thread thread)
        //{
        //    using var connection = new SqliteConnection(connectionString);
        //    var sqlQuery = $"SELECT Threads.Topic, Threads.Text, Threads.Author, Posts.Text, Posts.Author FROM Threads INNER JOIN Posts On Threads.ThreadId=Posts.ThreadId";
        //    var openThread = connection.Query<Thread>(sqlQuery, thread);
        //    return openThread.ToList();
        //}
        //select post.threadId, thread 
        public static void CreateNewThread(Thread thread)
        {
            using var connection = new SqliteConnection(connectionString);
            var data = "INSERT INTO Threads (Topic,Text,Author,PostCount) VALUES " +
                $"(@Topic, @Text, @Author, @PostCount)";
            var result = connection.Execute(data, thread);
        }
    }
}
