using RESTSqLite.BLL.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTSqlLite.BLL.Interface.Services
{
    public interface IPostService
    {
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<Post> AddAsync(Post createPostRequest);
        Task UpdateAsync(int id, UpdatePostRequest updatePostRequest);
    }
}
