using Microsoft.AspNetCore.Cors.Infrastructure;
using WebApp.Service;
using WebAppBook.Models;
using WebAppBook.Service;
using WebAppBook.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddHttpClient<IBookService, BookService>();
builder.Services.AddHttpClient<IPubService, PubService>();

SD.BookAPIBase = builder.Configuration["ServiceUrls:BookAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IPubService, PubService>();

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
