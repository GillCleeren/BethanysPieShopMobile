using System;
using System.Threading.Tasks;
using Akavache;
using BethanysPieShop.Mobile.Core.Constants;
using BethanysPieShop.Mobile.Core.Contracts.Repository;
using BethanysPieShop.Mobile.Core.Contracts.Services.Data;
using BethanysPieShop.Mobile.Core.Models;

namespace BethanysPieShop.Mobile.Core.Services.Data
{
    public class ShoppingCartDataService : BaseService, IShoppingCartDataService
    {
        private readonly IGenericRepository _genericRepository;

        public ShoppingCartDataService(IGenericRepository genericRepository, IBlobCache cache = null) : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<ShoppingCart> GetShoppingCart(string userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.ShoppingCartEndpoint}/{userId}"
            };

            var shoppingCart = await _genericRepository.GetAsync<ShoppingCart>(builder.ToString());

            return shoppingCart;
        }

        public async Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.AddShoppingCartItemEndpoint
            };

            var userShoppingCartItem = new UserShoppingCartItem
            {
                ShoppingCartItem = shoppingCartItem,
                UserId = userId
            };

            var result =
                await _genericRepository.PostAsync(builder.ToString(), userShoppingCartItem);

            return shoppingCartItem;
        }
    }
}
