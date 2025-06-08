using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ShopingListItem> ShopingListItems { get; set; }
    }
}
