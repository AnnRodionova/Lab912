using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;
using System.ComponentModel;
using System.Diagnostics;

namespace SportStore.Controllers
{
    //  онтроллер дл€ обработки запросов св€занных с домашней страницей и ошибками
    public class HomeController : Controller
    {
        
        private IStoreRepositiry repositiry;

        //  онструктор дл€ внедрени€ зависимости репозитори€
        public HomeController(IStoreRepositiry repositiry)
        {
            this.repositiry = repositiry;
        }

        //  онстанта дл€ указани€ размера страницы в пагинации
        public int PageSize = 4;

        // ћетод действи€ дл€ домашней страницы, отображающий список продуктов
        public ViewResult Index(string category, int productPage = 1)
        {
            
            return View(new ProductsListViewModel
            {
                // «апрос продуктов из репозитори€ в зависимости от указанной категории и параметров пагинации
                Products = repositiry.Products
                    .Where(p => category == null || p.Category == category) 
                    .OrderBy(p => p.ProductID) 
                    .Skip((productPage - 1) * PageSize) 
                    .Take(PageSize), 
                
                PaginInfo = new PaginInfo
                {
                    CurrentPage = productPage, 
                    ItemsPerPage = PageSize, 
                    TotalItems = repositiry.Products.Count() 
                }
            });
        }

        // ћетод действи€ дл€ отображени€ страницы с политикой конфиденциальности
        public IActionResult Privacy()
        {
            return View();
        }

        // ћетод действи€ дл€ обработки ошибок
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

