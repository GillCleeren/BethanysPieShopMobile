using BethanysPieShop.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Client.Contracts.Services.Data;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName,
        string password);

    Task<AuthenticationResponse> Authenticate(string userName, string password);

    bool IsUserAuthenticated();
}
