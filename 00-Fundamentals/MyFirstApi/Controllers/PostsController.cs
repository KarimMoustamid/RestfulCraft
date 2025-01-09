namespace MyFirstApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Linq;
    using Services;

    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly PostsService _postsService;

        public PostsController()
        {
            // The PostsController depends on the PostsService, and the PostsService is a dependency of the PostsController.
            // We can improve this implementation by creating a constructor injection. i.e. Dependency Inversion Principle.
            _postsService = new PostsService();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _postsService.GetAllPosts(); // Await the task to get the result
            if (posts == null || posts.Any())
            {
                return this.NoContent();
            }

            return this.Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postsService.GetPost(id);
            if (post == null)
            {
                return this.NotFound();
            }

            return this.Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post item)
        {
            await _postsService.CreatePost(item);
            return this.CreatedAtAction(nameof(GetPost), new {id = item.Id}, item);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, Post item)
        {
            if (id != item.Id)
            {
                return this.BadRequest();
            }

            var updatedPost = await _postsService.UpdatePost(id, item);
            if (updatedPost == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _postsService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }

            await _postsService.DeletePost(id);
            return NoContent();
        }
    }
}