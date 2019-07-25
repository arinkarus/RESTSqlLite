﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RESTSqLite.DAL.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
    }
}
