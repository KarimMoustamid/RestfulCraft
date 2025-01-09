namespace MyFirstApi.Services
{
    public class SingletonService : ISingletonService
    {
        public string Name { get; }
        private readonly Guid _serviceId;
        private readonly DateTime _createdAt;

        public SingletonService()
        {
            _serviceId = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
            Name = nameof(SingletonService);
        }

        public string SayHello()
        {
            return $"Hello I am {Name}. My Id is {_serviceId} . I was created at {_createdAt:yyyy-MM-dd HH:mm:ss}";
        }
    }
}