using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private const int INITIAL_PAGE_SIZE = 4;

        private readonly IStoreRepository repository;
        public int PageSize { get; set; } = INITIAL_PAGE_SIZE;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(string? category, int productPage = 1) => View(
            new ProductsListViewModel
            {
                Products = this.repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null 
                        ? repository.Products.Count()
                        : repository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
