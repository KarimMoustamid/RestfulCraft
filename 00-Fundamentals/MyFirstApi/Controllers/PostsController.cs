namespace MyFirstApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
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
    }
}