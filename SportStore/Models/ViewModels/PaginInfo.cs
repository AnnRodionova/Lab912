namespace SportStore.Models.ViewModels
{
    public class PaginInfo
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage()
        {
            return (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);
        }
    }
}
