using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<FavouriteHorse> FavouriteHorses { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<HorseReview> HorseReviews { get; set; }
    }
}
