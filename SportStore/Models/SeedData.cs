using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    // Класс для заполнения базы данных начальными данными
    public class SeedData
    {
        // Метод для обеспечения наличия начальных данных
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // Получаем контекст базы данных из сервисов приложения
            StoreDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<StoreDbContext>();

            // Применяем все ожидающие миграции, если они есть
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // Если в базе данных нет продуктов, добавляем начальные данные
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Каяк",
                        Description = "Лодка для одного человека",
                        Category = "Водный спорт",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Спортивный рюкзак",
                        Description = "Рюкзак для спортинвентаря",
                        Category = "Рюкзаки и сумки",
                        Price = 20
                    },
                    new Product
                    {
                        Name = "Футбольный мяч",
                        Description = "Установленный FIFA размер и вес",
                        Category = "Футбол",
                        Price = 15
                    },
                    new Product
                    {
                        Name = "Куртка зимняя Puma",
                        Description = "Зимняя одежда",
                        Category = "Верхняя одежда",
                        Price = 35
                    },
                    new Product
                    {
                        Name = "Волейбольный мяч",
                        Description = "Стандарт",
                        Category = "Волейбол",
                        Price = 11
                    }
                );
                // Сохраняем изменения в базе данных
                context.SaveChanges();
            }
        }
    }
}
