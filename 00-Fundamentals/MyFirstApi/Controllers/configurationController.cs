namespace MyFirstApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class configurationController(IConfiguration configuration) : ControllerBase
    {

        [HttpGet]
        [Route("my-key")]
        public ActionResult GetKey()
        {
            var myKey = configuration["myKey"];
            return Content(myKey);
        }

        [HttpGet]
        [Route("database-configuration")]
        public ActionResult GetDatabaseConfiguration()
        {
            var type = configuration["Database:Type"];
            var connectionString = configuration["Database:ConnectionString"];

            return this.Ok(new { Type = type, ConnectionString = connectionString});
        }
    }
}