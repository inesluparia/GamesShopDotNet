using Microsoft.EntityFrameworkCore;

namespace GamesShop.Models
{
    public class GameShopDbContext : DbContext
    {
        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }   

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=?,database=?,user=?,password=?;");
        //}
    }
}
