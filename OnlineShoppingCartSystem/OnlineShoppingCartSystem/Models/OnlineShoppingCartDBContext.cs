using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingCartSystem.Models
{
    public class OnlineShoppingCartDBContext : DbContext
    {
        public OnlineShoppingCartDBContext(DbContextOptions<OnlineShoppingCartDBContext>options) : base(options)
        {
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
