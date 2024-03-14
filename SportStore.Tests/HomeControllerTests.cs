using Microsoft.AspNetCore.Mvc;
using Moq;
using SportStore.Controllers;
using SportStore.Models;

namespace Product.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            //Организация
            Mock<IStoreRepositiry> mock = new Mock<IStoreRepositiry>();
            mock.Setup(m => m.Products).Returns((new SportStore.Models.Product[]
                {
                    new SportStore.Models.Product { ProductID = 1, Name = "P1" },
                    new SportStore.Models.Product { ProductID = 2, Name = "P2" }
                }).AsQueryable<SportStore.Models.Product>());
            HomeController controller = new HomeController(mock.Object);
            //Действие
            IEnumerable<SportStore.Models.Product> result =
                (controller.Index() as ViewResult).ViewData.Model as IEnumerable<SportStore.Models.Product>;
            //Утверждение
            SportStore.Models.Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);

        }
    }
}
