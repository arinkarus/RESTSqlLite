using System;
using System.Collections.Generic;
using System.Text;

namespace RESTSqLite.BLL.Interface.Models
{
    public class ImageUploadRequest
    {
        public string FilePath { get; set; }
        public string Content { get; set; }
    }
}
