namespace ConfigurationDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
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
            var databaseOptions = new DatabaseOption();

            //The `SectionName` is defined in the `DatabaseOption` class, which shows the section name in the `appsettings.json` file.
            configuration.GetSection(DatabaseOption.SectionName).Bind(databaseOptions);

            return this.Ok(new
            {
                databaseOptions.Type,
                databaseOptions.ConnectionString
            });
        }

        [HttpGet]
        [Route("database-configuration-with-generic-type")]
        public ActionResult GetDatabaseConfigurationWithGenericType()
        {
            var databaseOptions = configuration.GetSection(DatabaseOption.SectionName).Get<DatabaseOption>();

            return this.Ok(new
            {
                databaseOptions.Type,
                databaseOptions.ConnectionString
            });
        }

        [HttpGet]
        [Route("database-configuration-with-ioptions")]
        public ActionResult GetDatabaseConfigurationWithIOptions([FromServices] IOptions<DatabaseOption> options)
        {
            var databaseOptions = options.Value;
            return this.Ok(new
            {
                databaseOptions.Type,
                databaseOptions.ConnectionString
            });
        }

        [HttpGet]
        [Route("database-configuration-with-ioptions-snapshot")]
        public ActionResult GetDatabaseConfigurationWithIOptionsSnapshot([FromServices] IOptionsSnapshot<DatabaseOption> options)
        {
            var databaseOption = options.Value;
            return Ok(new { databaseOption.Type, databaseOption.ConnectionString });
        }

        [HttpGet]
        [Route("database-configuration-with-ioptions-monitor")]
        public ActionResult GetDatabaseConfigurationWithIOptionsMonitor([FromServices] IOptionsMonitor<DatabaseOption> options)
        {
            var databaseOption = options.CurrentValue;
            return Ok(new { databaseOption.Type, databaseOption.ConnectionString });
        }

        [HttpGet]
        [Route("database-configuration-with-named-options")]
        public ActionResult GetDatabaseConfigurationWithNamedOptions([FromServices] IOptionsSnapshot<DatabaseOptions> options)
        {
            var systemDatabaseOption = options.Get(DatabaseOptions.SystemDatabaseSectionName);
            var businessDatabaseOption = options.Get(DatabaseOptions.BusinessDatabaseSectionName);
            return Ok(new { SystemDatabaseOption = systemDatabaseOption, BusinessDatabaseOption = businessDatabaseOption });
        }
    }
}