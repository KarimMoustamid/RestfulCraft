using MyFirstApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// NOTE : Group registration
builder.Services.AddLifetimeServices();

// Configure routing with lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var service = serviceScope.ServiceProvider;
    var demoService = service.GetRequiredService<IDemoService>();
    var message = demoService.SayHello();
    Console.WriteLine(message);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


/*
 This line of code adds endpoints for controller actions to the IEndpointRouteBuilder instance without specifying any routes. To specify the routes, we need to use the [Route] attribute on the controller class and the action methods.
 */
app.MapControllers();

app.Run();