using System;
using System.Collections.Generic;
using System.Text;

namespace RESTSqLite.BLL.Interface.Models
{
    public class UpdatePostRequest
    {
        public string Text { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
    }
}
