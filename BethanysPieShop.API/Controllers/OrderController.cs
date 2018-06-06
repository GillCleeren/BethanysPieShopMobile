using System.Linq;
using BethanysPieShop.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        // GET: /<controller>/
        public IActionResult Add([FromBody]Order order)
        {
            //handling of order not fully implemented in this demo
            var shoppingCart = _appDbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == order.UserId);
            var shoppingCartItemsToRemove =
                _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == shoppingCart.ShoppingCartId);
            _appDbContext.ShoppingCartItems.RemoveRange(shoppingCartItemsToRemove);
            _appDbContext.SaveChanges();

            return Ok(order);
        }
    }
}
