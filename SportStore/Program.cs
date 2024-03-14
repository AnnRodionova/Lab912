using Microsoft.EntityFrameworkCore;
using SportStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Регистрация контекста данных
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportStoreConnection")));

builder.Services.AddScoped<IStoreRepositiry, EFStoreRepository>();

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("catpage",
        "(category/Page(productPage:int)",
        new { Controller = "Home", action = "Index" });

    endpoints.MapControllerRoute("page", "Page{productPage:int}",
        new { Controller = "Home", action = "Index", productPage = 1 });

    endpoints.MapControllerRoute("category", "{category}",
        new { Controller = "Home", action = "Index", productPage = 1 });

    endpoints.MapControllerRoute("pagination", "Products/Page{productPage}",
        new { Controller = "Home", action = "Index" });

    endpoints.MapDefaultControllerRoute();

    endpoints.MapRazorPages();

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

SeedData.EnsurePopulated(app);

app.Run();