namespace MyFirstApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly PostsService _postsService;

        public PostsController()
        {
            _postsService = new PostsService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Post 1",
                    Body = "Post 1 body"
                },
                new Post
                {
                    Id = 2,
                    UserId = 1,
                    Title = "Post 2",
                    Body = "Post 2 body"
                },
                new Post
                {
                    Id = 3,
                    UserId = 2,
                    Title = "Post 3",
                    Body = "Post 3 body"
                },
            };
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
    }
}