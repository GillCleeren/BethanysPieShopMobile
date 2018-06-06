using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.API.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        public Pie Pie { get; set; }

        public int PieId { get; set; }

        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
