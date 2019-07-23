using System;
using System.Collections.Generic;
using System.Text;

namespace RESTSqLite.BLL.Interface.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string FullText { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
    }
}
