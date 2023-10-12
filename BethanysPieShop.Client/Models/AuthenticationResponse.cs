namespace BethanysPieShop.Client.Models;

public class AuthenticationResponse
{
    public bool IsAuthenticated { get; set; }
    public User User { get; set; }
}
