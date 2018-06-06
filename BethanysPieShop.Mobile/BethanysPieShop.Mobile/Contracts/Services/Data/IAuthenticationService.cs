using System.Threading.Tasks;
using BethanysPieShop.Mobile.Core.Models;

namespace BethanysPieShop.Mobile.Core.Contracts.Services.Data
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName,
            string password);

        Task<AuthenticationResponse> Authenticate(string userName, string password);

        bool IsUserAuthenticated();
    }
}
