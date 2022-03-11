using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumAssignment.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int PostCount { get; set; }

    }
}
