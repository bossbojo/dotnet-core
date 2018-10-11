using AppApi.Repositories.Implements;
using AppApi.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AppApi.Dependencies
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionServices(IServiceCollection services){
            services.AddScoped<IUsers,EFUsers>();
        }
    }
}