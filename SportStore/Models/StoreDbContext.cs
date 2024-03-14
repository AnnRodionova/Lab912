using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    // Контекст базы данных для взаимодействия с базой данных
    public class StoreDbContext : DbContext
    {
        // Конструктор контекста базы данных, принимающий опции контекста
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        // Набор сущностей продуктов в базе данных
        public DbSet<Product> Products { get; set; }
    }
}

