using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;

var builder = WebApplication.CreateBuilder(args);
// creates db connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// adds services to the container.
builder.Services.AddControllersWithViews();

// adds db connection
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
