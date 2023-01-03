using SportsStore.Models;
using System.Runtime.CompilerServices;

namespace SportsStore.Configurations
{
    public static class DIConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<SeedData, SeedData>();
            services.AddScoped<StoreDbContext, StoreDbContext>();
            services.AddScoped<IStoreRepository, EFStoreRepository>();
        }
    }
}
