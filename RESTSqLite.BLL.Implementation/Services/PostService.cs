using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTSqLite.BLL.Interface.Exceptions;
using RESTSqLite.BLL.Interface.Models;
using RESTSqLite.DAL.Models;
using RESTSqlLite.BLL.Interface.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTSqLite.BLL.Implementation
{
    public class PostService : IPostService
    {
        private readonly PostsContext context;

        private readonly IMapper mapper;

        public PostService(PostsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Interface.Models.Post> GetByIdAsync(int id)
        {
            var dbPost = await this.context.Posts.FindAsync(id);
            if (dbPost == null)
            {
                throw new ResourceNotFoundException();
            }

            return this.mapper.Map<RESTSqLite.DAL.Models.Post, Interface.Models.Post>(dbPost);
        }

        public async Task<IEnumerable<Interface.Models.Post>> GetAllAsync()
        {
            var dbPosts = await this.context.Posts.OrderBy(p => p.Id).ToArrayAsync();
            var servicePosts = dbPosts.Select(p => this.mapper.Map<RESTSqLite.DAL.Models.Post, Interface.Models.Post>(p));
            return servicePosts;
        }

        public async Task DeleteAsync(int id)
        {
            var postToDelete = await this.context.Posts.FindAsync(id);
            if (postToDelete == null)
            {
                throw new ResourceNotFoundException();
            }

            this.context.Remove(postToDelete);
            await this.context.SaveChangesAsync();
        }

        public async Task<Interface.Models.Post> AddAsync(Interface.Models.Post post)
        {
            var dbPost = this.mapper.Map<Interface.Models.Post, RESTSqLite.DAL.Models.Post>(post);
            await this.context.AddAsync(dbPost);
            await this.context.SaveChangesAsync();
            var createdPost = this.mapper.Map<Interface.Models.Post>(dbPost);
            return createdPost;
        }

        public async Task UpdateAsync(int id, UpdatePostRequest updatePostRequest)
        {
            var dbPost = await this.context.Posts.FindAsync(id);
            if (dbPost == null)
            {
                throw new ResourceNotFoundException();
            }

            this.mapper.Map(updatePostRequest, dbPost);
            await this.context.SaveChangesAsync();
        }
    }
}
