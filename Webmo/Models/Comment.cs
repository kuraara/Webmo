using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webmo.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public DateTime Posted { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        
    }
}