using BethanysPieShop.API.Models;

namespace BethanysPieShop.API.ViewModel
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}
