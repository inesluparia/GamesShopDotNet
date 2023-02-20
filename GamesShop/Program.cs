using GamesShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameShopDbContext>(options =>
{
    options.UseMySQL(
        builder.Configuration["ConnectionStrings:GamesShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}

app.MapDefaultControllerRoute();//{contorller=Home}/{action=Index}/{id?}

DbInitializer.Seed(app);
app.Run();
