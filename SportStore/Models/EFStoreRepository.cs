namespace SportStore.Models
{
    // Репозиторий для работы с базой данных с использованием Entity Framework
    public class EFStoreRepository : IStoreRepositiry
    {
        // Контекст базы данных
        private StoreDbContext context;

        // Конструктор для внедрения зависимости контекста базы данных
        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        // Свойство, предоставляющее доступ к коллекции продуктов
        public IQueryable<Product> Products => context.Products;
    }
}

