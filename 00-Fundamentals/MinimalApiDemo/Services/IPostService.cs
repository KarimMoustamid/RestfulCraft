namespace MyFirstApi.Services
{
    using Models;

    public interface IPostService
    {
        Task CreatePostAsync(Post item);
        Task<Post?> UpdatePostAsync(int id, Post item);
        Task<Post?> GetPostAsync(int id);
        Task<List<Post>> GetPostsAsync();

        Task DeletePostAsync(int id);
    }
}