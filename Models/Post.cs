using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumAssignment.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int ThreadId { get; set; }
    }
}
