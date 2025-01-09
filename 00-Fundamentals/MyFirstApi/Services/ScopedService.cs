namespace MyFirstApi.Services
{
    public class ScopedService :IScoredService
    {
        public string Name { get; }
        private readonly Guid _serviceId;
        private readonly DateTime _createdAt;

        public ScopedService()
        {
            _serviceId = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
            Name = nameof(ScopedService);
        }

        public string SayHello()
        {
            return $"Hello I am {Name}. My Id is {_serviceId} . I was created at {_createdAt:yyyy-MM-dd HH:mm:ss}";
        }
    }
}