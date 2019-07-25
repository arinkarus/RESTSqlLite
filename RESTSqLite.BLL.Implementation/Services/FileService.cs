using Microsoft.EntityFrameworkCore;
using RESTSqLite.BLL.Interface.Services;
using RESTSqLite.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTSqLite.BLL.Implementation.Services
{
    public class FileService : IFileService
    {
        private readonly PostsContext context;

        public FileService(PostsContext postsContext)
        {
            this.context = postsContext;
        }

        public Folder Get()
        {
            var folder = this.context.Folders.Find(3);
            this.context.Entry(folder).Reference(s => s.ParentFolder).Load();
            var parentFolder = folder.ParentFolder;
            this.context.Entry(parentFolder).Reference(s => s.ParentFolder).Load();
            return folder;
        }
    }
}
