using Microsoft.AspNetCore.Mvc;
using SimpleApp.DataAccess;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataSource dataSource;

        public HomeController(IDataSource dataSource)
        {
            this.dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }
        public IActionResult Index()
        {
            return View(this.dataSource.Products); ;
        }
    }
}
