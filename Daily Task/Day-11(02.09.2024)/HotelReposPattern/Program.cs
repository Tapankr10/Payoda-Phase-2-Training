using HotelReposPattern.Models;
using HotelReposPattern.Repository;
using HotelReposPattern.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer("data source=PTSQLTESTDB01;database= Hotel_tapan;integrated security=true;TrustServerCertificate=true;"));
builder.Services.AddScoped<IHotel, HotelService>();
builder.Services.AddScoped<IRoom, Roomservice>();



var app = builder.Build();
//builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer("data source=PTSQLTESTDB01;database=Hotel_tapan;integrated security=true;TrustServerCertificate=true;"));

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
