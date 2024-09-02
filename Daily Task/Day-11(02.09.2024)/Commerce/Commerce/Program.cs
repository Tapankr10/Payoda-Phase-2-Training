using Commerce.Models;
using Commerce.Repository;
using Commerce.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CustomersDbcontext>(options => options.UseSqlServer("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;TrustServerCertificate=true;"));
builder.Services.AddScoped<IOrders,OrdersService>();
builder.Services.AddScoped<ICustomers,CustomersService>();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
