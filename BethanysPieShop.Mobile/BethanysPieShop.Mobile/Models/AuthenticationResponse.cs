namespace BethanysPieShop.Mobile.Core.Models
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}
