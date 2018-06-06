namespace BethanysPieShop.Mobile.Core.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Pie Pie { get; set; }

        public int PieId { get; set; }

        public int Quantity { get; set; }

        public decimal Total => Quantity * Pie.Price;
    }
}
