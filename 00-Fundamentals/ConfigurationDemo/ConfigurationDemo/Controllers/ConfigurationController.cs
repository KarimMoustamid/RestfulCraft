namespace ConfigurationDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController(IConfiguration configuration) : ControllerBase
    {
        [HttpGet]
        [Route("my-key")]
        public ActionResult GetConfiguration()
        {
            var MyKey = configuration["MyKey"];
            return this.Ok(MyKey);
        }

        [HttpGet]
        [Route("database-configuration")]
        public ActionResult GetDatabaseConfiguration()
        {
            var type = configuration["Database:Type"];
            var connectionString = configuration["Database:ConnectionString"];
            return this.Ok(new
            {
                type = type,
                connectionString = connectionString
            });
        }
    }
}