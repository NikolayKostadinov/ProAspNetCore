using SportsStore.Models;
using System.Runtime.CompilerServices;

namespace SportsStore.Configurations
{
    public static class SeedConfig
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            app.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<SeedData>()
                .EnsurePopulated();
        }
    }
}
