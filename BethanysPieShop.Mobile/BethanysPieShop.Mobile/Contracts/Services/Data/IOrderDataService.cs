using System.Threading.Tasks;
using BethanysPieShop.Mobile.Core.Models;

namespace BethanysPieShop.Mobile.Core.Contracts.Services.Data
{
    public interface IOrderDataService
    {
        Task<Order> PlaceOrder(Order order);
    }
}
