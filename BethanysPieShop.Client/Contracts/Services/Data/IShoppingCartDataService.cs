using BethanysPieShop.Client.Models;

namespace BethanysPieShop.Client.Contracts.Services.Data;

public interface IShoppingCartDataService
{
    Task<ShoppingCart> GetShoppingCart(string userId);
    Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
}
