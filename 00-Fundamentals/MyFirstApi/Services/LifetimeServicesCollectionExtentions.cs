namespace MyFirstApi.Services
{
    public static class LifetimeServicesCollectionExtentions
    {
        public static IServiceCollection AddLifetimeServices(this IServiceCollection services)
        {
            services.AddTransient<ITransientService, TransientService>();
            services.AddSingleton<ISingletonService, SingletonService>();
            services.AddScoped<IScoredService, ScopedService>();
            services.AddScoped<IPostService, PostsService>();
            services.AddScoped<IDemoService, DemoService>();

            return services;
        }
    }
}