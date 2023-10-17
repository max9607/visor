using PLVISORTELERIK.Repositorios;





namespace PLVISORTELERIK.Configuration
{
    public static class confHttpClient
    {
        public static IHttpClientBuilder AddConfReposirioHTTP(this IServiceCollection services, ConfigurationManager configuration)
        {
            return services.AddHttpClient<IRepositorio, Repositorio>((serviceProvider, options) =>
            {
                options.BaseAddress = new Uri(configuration["endpoints:api"]!);
            });
        }
    }
}