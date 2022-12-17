using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleApp.Controllers;
using SimpleApp.DataAccess;
using SimpleApp.Models;
using SimpleApp.Tests.Infrastructure;

namespace SimpleApp.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            Product[] testData = new Product[] {
                new Product { Name = "P1", Price = 75.10M },
                new Product { Name = "P2", Price = 120M },
                new Product { Name = "P3", Price = 110M }
            };

            var mockDataSource = new Mock<IDataSource>();
            mockDataSource.SetupGet(m => m.Products).Returns(testData);

            var controller = new HomeController(mockDataSource.Object);

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(testData, model!,
            Comparer.Get<Product>((p1, p2) => p1?.Name == p2?.Name && p1?.Price == p2?.Price));

            mockDataSource.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
