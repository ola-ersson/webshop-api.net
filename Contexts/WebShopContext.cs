using Microsoft.EntityFrameworkCore;

public class WebshopContext : DbContext {
    public WebshopContext(DbContextOptions<WebshopContext> options) 
        : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DB/webshop.db");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderRow> OrderRows { get; set; }
}