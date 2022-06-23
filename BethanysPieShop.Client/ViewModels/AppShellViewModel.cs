using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;

namespace BethanysPieShop.Client.ViewModels;

public class AppShellViewModel : ViewModelBase
{
    private readonly IAuthenticationService _authenticationService;
    public AppShellViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        : base(navigationService)
    {
        _authenticationService = authenticationService;
    }

    private string _greeting;

    public string Greeting
    {
        get { return _greeting; }
        set { _greeting = value; OnPropertyChanged(); }
    }

    public bool IsAuthenticated => _authenticationService.IsUserAuthenticated();


    public override async void OnAppearing()
    {
        Greeting = "Well, hello there!";
        if (!IsAuthenticated)
        {
            await _navigationService.NavigateAsync(NavigationConstants.Login);
        }
    }

    // ToDo: Subscribe to message Authentication Succes and update Greeting
    // ToDo: Make IsAuthenticated a property that you can raise => update UI
}
