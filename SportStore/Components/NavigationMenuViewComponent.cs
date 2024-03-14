using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepositiry repositiry;

        public NavigationMenuViewComponent (IStoreRepositiry repositiry)
        {
            this.repositiry = repositiry;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repositiry.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
