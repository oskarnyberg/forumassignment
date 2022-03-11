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
    public class PostRepository
    {
        private const string connectionString = "Data Source =.\\database.db";

        public static List<Post> ListPosts(Thread thread)
        {
            using var connection = new SqliteConnection(connectionString);
            var data = connection.Query<Post>($"SELECT * FROM Posts WHERE ThreadId = {thread.ThreadId}");
            return data.ToList();
        }

        public static void CreatePost(Post post)
        {
            using var connection = new SqliteConnection(connectionString);
            var data = "INSERT INTO Posts (Text,Author,ThreadId) VALUES " +
                $"(@Text, @Author, @ThreadId)";
            var result = connection.Execute(data, post);
        }

        public static void UpdatePost(Post post)
        {
            using var connection = new SqliteConnection(connectionString);
            var sqlQuery = $"UPDATE Posts SET Text = @Text WHERE PostId = @PostId";
            connection.Execute(sqlQuery, post);
        }

        public static void DeletePost(Post post)
        {
            using var connection = new SqliteConnection(connectionString);
            var sqlQuery = $"DELETE FROM Posts WHERE PostId = @PostId";
            connection.Execute(sqlQuery, post);
        }
    }
}
