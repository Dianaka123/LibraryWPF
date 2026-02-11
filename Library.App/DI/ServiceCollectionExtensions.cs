using Microsoft.Extensions.DependencyInjection;

namespace Library.App.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFactory<T>(this IServiceCollection services) where T : class
        {
            services.AddTransient<T>();
            return services.AddSingleton<IFactory<T>, Factory<T>>();
        }
    }
}
