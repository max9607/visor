

using PLVISORTELERIK.Helpers;


namespace SAADS.FIN.WEB.Configuration
{
    public static class confRN
    {
        public static IServiceCollection AddconfRN(this IServiceCollection services)
        {

            RegisterBussinessRules(services);
            return services;
        }

        private static IServiceCollection RegisterBussinessRules(this IServiceCollection services)
        {
            // here come our Dependency Inyection
            //services.AddTransient<AccesoRN>();
            //services.AddTransient<FacturaRN>();

            return services;

        }
    }
}
