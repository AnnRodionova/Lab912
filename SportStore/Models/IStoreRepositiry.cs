namespace SportStore.Models
{
    public interface IStoreRepositiry
    {
        IQueryable<Product>Products { get; }
    }
}
