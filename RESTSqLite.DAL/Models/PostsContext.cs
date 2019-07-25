using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RESTSqLite.DAL.Models
{
    public class PostsContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Post> Posts { get; set; }

        public PostsContext(DbContextOptions<PostsContext> options) : base(options)
        {

        }
    }
}
