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

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<CaptchaConfig>(builder.Configuration.GetSection("GoogleReCaptcha"));
builder.Services.AddTransient(typeof(CaptchaService));


var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseCookiePolicy();

app.Run();
