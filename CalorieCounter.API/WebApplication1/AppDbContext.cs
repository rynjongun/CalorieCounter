using Microsoft.EntityFrameworkCore;
using WebApplication1;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<FoodItem> FoodItems { get; set; }
}
