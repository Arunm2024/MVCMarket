using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("test"));
});
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name:"default", 
    pattern:"{controller=Home}/{action=index}/{id?}");
app.Run();
