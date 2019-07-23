using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTSqLite.BLL.Interface.Models;
using RESTSqLite.CustomFilters;
using RESTSqlLite.BLL.Interface.Services;

namespace RESTSqLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await this.postService.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPost")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await this.postService.GetByIdAsync(id);
            return Ok(post);
        } 
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.postService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Post post)
        {
            var createdPost = await this.postService.AddAsync(post);      
            return CreatedAtRoute("GetPost", new { id = createdPost.Id }, createdPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdatePostRequest updatePostRequest)
        {
            await this.postService.UpdateAsync(id, updatePostRequest);
            return NoContent();
        }
    }
}