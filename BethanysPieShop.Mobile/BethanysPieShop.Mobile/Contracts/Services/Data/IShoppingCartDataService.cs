using System.Threading.Tasks;
using BethanysPieShop.Mobile.Core.Models;

namespace BethanysPieShop.Mobile.Core.Contracts.Services.Data
{
    public interface IShoppingCartDataService
    {
        Task<ShoppingCart> GetShoppingCart(string userId);
        Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
    }
}
