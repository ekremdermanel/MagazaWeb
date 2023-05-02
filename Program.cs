using MagazaWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MagazaContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("BaglantiMySQL")));
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
