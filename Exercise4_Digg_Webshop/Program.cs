using Exercise4_Digg_Webshop.Data;
using Exercise4_Digg_Webshop.Models;
using Exercise4_Digg_Webshop.Models.Entities;
using Exercise4_Digg_Webshop.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddDbContext<IdentityDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql2")));
builder.Services.AddScoped<IProductService, ProductService>();



//Configure Authentication and Authorization
builder.Services.AddAuthentication(x =>
    x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme
);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();
builder.Services.AddMemoryCache();



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

app.UseAuthentication();
app.UseAuthorization(); //Authorization

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

//Seed Database
AppDbSeeder.SeedProducts(app);
AppDbSeeder.SeedUsersAndRolesAsync(app).Wait();
AppDbSeeder.SeedBlog(app);

app.Run();
