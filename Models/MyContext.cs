// disables warning "non-nullable field must contain..."
// can disable safely bc fw will asssign non-null val whens it constructs class
#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models;
// MyContext class representing a sess w/MySQL db, allowing you to query for or save data
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    // "Dishes" table name will come from the DbSet property name
    public DbSet<Dish> Dishes { get; set; } 
}

// appsettings.json note
// don't forget to change password to rootroot and database to modelnamedb