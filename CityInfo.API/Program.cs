var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
});
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.Add("server", Environment.MachineName);
    };
});
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
app.UseRouting();
app.UseAuthorization();
// app.UseEndpoints(endpoint => endpoint.MapControllers());
app.MapControllers();

// Middleware to handle all incoming requests and respond with "Hello World!"
// app.Run(async (context) =>
// {
//     await context.Response.WriteAsync("Hello World!");
// });

app.Run();