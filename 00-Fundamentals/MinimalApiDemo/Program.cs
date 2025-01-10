using MyFirstApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var list = new List<Post>()
{
    new Post() {Id = 1, Title = "Title 1", Content = "Content 1"},
    new Post() {Id = 2, Title = "Title 2", Content = "Content 2"},
    new Post() {Id = 3, Title = "Title 3", Content = "Content 3"},
    new Post() {Id = 4, Title = "Title 4", Content = "Content 4"},
};

app.MapGet("/posts",
    async (IPostService postService) =>
    {
        var posts = await postService.GetPostsAsync();
        return posts;
    }).WithName("GetPosts").WithOpenApi().WithTags("Posts");

app.MapGet("/posts/{id}",
    async (IPostService postService, int id) =>
    {
        var post = await postService.GetPostAsync(id);
        return post == null ? Results.NotFound() : Results.Ok(post);
    }).WithName("GetPost").WithOpenApi().WithTags("Posts");

app.MapPost("/posts",
    async (IPostService postService, Post post) =>
    {
        var createdPost = await postService.CreatePostAsync(post);
        return Results.Created($"/posts/{createdPost.Id}", createdPost);
    }).WithName("CreatePost").WithOpenApi().WithTags("Posts");

app.MapPut("/posts/{id}",
    async (IPostService postService, int id, Post post) =>
    {
        try
        {
            var updatedPost = await postService.UpdatePostAsync(id, post);
            return Results.Ok(updatedPost);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound();
        }
    }).WithName("UpdatePost").WithOpenApi().WithTags("Posts");

app.Run();

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}