using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineStore
{
    public class OnlineHorseStoreReview : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<HorseReview> HorseReviews { get; set; }
        public DbSet<FavouriteHorse> FavoriteHorses { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public OnlineHorseStoreReview() : base("OnlineHorseStoreContext")
        {
        }
    }
}
