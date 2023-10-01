namespace Application.Extensions
{
    public static class Extension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITracksService, TracksService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    
        }
    }
}