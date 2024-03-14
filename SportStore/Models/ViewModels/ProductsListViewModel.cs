namespace SportStore.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set;}

        public PaginInfo PaginInfo { get; set;}

        public string CurrentCategory { get; set; }
    }
}
