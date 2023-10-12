using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Repository;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Models;

namespace BethanysPieShop.Client.Services.Data;

public class AuthenticationService : IAuthenticationService
{
    private readonly IGenericRepository _genericRepository;
    private readonly ISettingsService _settingsService;
    public AuthenticationService(IGenericRepository genericRepository, ISettingsService settingsService)
    {
        _settingsService = settingsService;
        _genericRepository = genericRepository;
    }

    public async Task<AuthenticationResponse> Authenticate(string userName, string password)
    {
        UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        {
            Path = ApiConstants.AuthenticateEndpoint
        };

        AuthenticationRequest authenticationRequest = new AuthenticationRequest()
        {
            UserName = userName,
            Password = password
        };

        return await _genericRepository.PostAsync<AuthenticationRequest, AuthenticationResponse>(builder.ToString(), authenticationRequest);
    }

    public bool IsUserAuthenticated()
    {
        return !string.IsNullOrEmpty(_settingsService.UserIdSetting);
    }

    public async Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName, string password)
    {
        UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        {
            Path = ApiConstants.RegisterEndpoint
        };

        AuthenticationRequest authenticationRequest = new AuthenticationRequest()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            UserName = userName,
            Password = password
        };

        return await _genericRepository.PostAsync<AuthenticationRequest, AuthenticationResponse>(builder.ToString(), authenticationRequest);
    }
}
