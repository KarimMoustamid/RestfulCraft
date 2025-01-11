namespace ConfigurationDemo.Options
{
    public class DatabaseOptions
    {
        public const string SectionName = "Database";
        public string Type { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
    }
}