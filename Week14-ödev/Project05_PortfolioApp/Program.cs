using System.Data;
using System.Data.SqlClient;
using Project05_PortfolioApp.Data;
using Project05_PortfolioApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbConnection>(option => new SqlConnection(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(DapperRepository<>));

builder.Services.AddScoped<ImageHelper>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "adminArea",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}",
    areaName: "Admin"
);
//localhost:5500/admin/home/index

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//localhost:5500/home/about


app.Run();
