namespace ConfigurationDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Options;

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

        [HttpGet]
        [Route("database-configuration-with-bind")]
        public ActionResult GetDatabaseConfigurationWithBind()
        {
            var databaseOptions = new DatabaseOptions();

            //The `SectionName` is defined in the `DatabaseOption` class, which shows the section name in the `appsettings.json` file.
            configuration.GetSection(DatabaseOptions.SectionName).Bind(databaseOptions);

            return this.Ok(new
            {
                databaseOptions.Type,
                databaseOptions.ConnectionString
            });
        }
    }
}