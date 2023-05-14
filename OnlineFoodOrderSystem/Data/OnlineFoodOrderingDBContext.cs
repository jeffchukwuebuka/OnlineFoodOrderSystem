using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderSystem.Models;

namespace OnlineFoodOrderSystem.Data
{
    public class OnlineFoodOrderingDBContext: DbContext
    {
        public OnlineFoodOrderingDBContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order>Orders{get;set; }    
    }
}
