namespace SportsStore.Configurations
{
    public static class RoutingConfiguration
    {
        public static void UseRoutes(this WebApplication app)
        {
            app.MapControllerRoute("catpage", "{category}/Page{productPage:int}",    
                new { Controller = "Home", action = "Index" });

            app.MapControllerRoute("page", "Page{productPage:int}",
                new { Controller = "Home", action = "Index", productPage = 1 });

            app.MapControllerRoute("category", "{category}",
                new { Controller = "Home", action = "Index", productPage = 1 });

            app.MapControllerRoute("pagination", "Products/Page{productPage}",
                new { Controller = "Home", action = "Index", productPage = 1 });

            app.MapDefaultControllerRoute();
        }
    }
}
