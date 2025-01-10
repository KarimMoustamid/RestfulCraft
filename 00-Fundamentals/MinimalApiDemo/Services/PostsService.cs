namespace MyFirstApi.Services
{
    using Models;

    public class PostsService : IPostService
    {
        // TODO : fix the service
        private static readonly List<Post> AllPosts = new();

        public Task CreatePostAsync(Post item)
        {
            AllPosts.Add(item);
            return Task.CompletedTask;
        }

        public Task<Post?> UpdatePostAsync(int id, Post item)
        {
            var post = AllPosts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                post.Title = item.Title;
                post.Body = item.Body;
                post.UserId = item.UserId;
            }

            return Task.FromResult(post);
        }

        public Task<Post?> GetPostAsync(int id)
        {
            return Task.FromResult(AllPosts.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Post>> GetPostsAsync()
        {
            return Task.FromResult(AllPosts);
        }

        public Task DeletePostAsync(int id)
        {
            var post = AllPosts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                AllPosts.Remove(post);
            }

            return Task.CompletedTask;
        }
    }
}