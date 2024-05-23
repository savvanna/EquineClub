using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore
{
    public class Horse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HorseId { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<FavouriteHorse> FavouriteHorses { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public ICollection<HorseReview> HorseReviews { get; set; }
    }
}
