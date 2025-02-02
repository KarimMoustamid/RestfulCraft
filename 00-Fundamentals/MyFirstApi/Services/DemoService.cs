namespace MyFirstApi.Services
{
    public class DemoService : IDemoService
    {
        private readonly Guid _serviceId;
        private readonly DateTime _createdAt;

        public DemoService()
        {
            _serviceId = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
        }

        public string SayHello()
        {
            return $"Hello from {_serviceId} created at {_createdAt:yyyy-MM-dd HH:mm:ss}";
        }
    }
}