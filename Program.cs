using MagazaWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MagazaContext>(options => options.UseMySQL(builder.
Configuration.GetConnectionString("BaglantiMySQL")));

builder.Services.AddIdentity<Kullanici, IdentityRole>().AddEntityFrameworkStores<MagazaContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Kullanici/Login";
    options.LogoutPath = "/Kullanici/Logout";
    options.AccessDeniedPath = "/Kullanici/Yetki";
});

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseAuthentication();
app.UseAuthorization();

app.Run();
