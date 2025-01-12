namespace ConfigurationDemo.Options
{
    public class DatabaseOptions
    {
        public const string SystemDatabaseSectionName = "System";
        public const string BusinessDatabaseSectionName = "Business";
        public string Type { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public const string SectionName = "Database";

    }
}