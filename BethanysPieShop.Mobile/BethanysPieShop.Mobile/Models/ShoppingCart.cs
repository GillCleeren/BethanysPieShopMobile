using System.Collections.Generic;

namespace BethanysPieShop.Mobile.Core.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
