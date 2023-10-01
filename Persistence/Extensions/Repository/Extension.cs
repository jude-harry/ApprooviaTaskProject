namespace Persistence.Extensions.Repository
{
    public static class Extension
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAsyncRepository<TaskProject>, AsyncRepository<TaskProject>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}