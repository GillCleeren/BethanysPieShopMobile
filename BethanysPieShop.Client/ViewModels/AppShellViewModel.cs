using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;

namespace BethanysPieShop.Client.ViewModels;

public class AppShellViewModel : ViewModelBase
{
    private string _greeting;
    private bool _isAuthenticated;

    private readonly IAuthenticationService _authenticationService;
   
    public AppShellViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        : base(navigationService)
    {
        _authenticationService = authenticationService;

        MessagingCenter.Subscribe<LoginViewModel>(this, MessagingConstants.LoginSucceeded, (loginViewModel) => OnLoginSucceeded());
    }

    
    public string Greeting
    {
        get { return _greeting; }
        set { _greeting = value; OnPropertyChanged(); }
    }

    public bool IsAuthenticated
    {
        get { return _isAuthenticated; }
        set { _isAuthenticated = value; OnPropertyChanged(); }
    }
    

    public override async void OnAppearing()
    {
        Greeting = "Well, hello there!";
        IsAuthenticated = _authenticationService.IsUserAuthenticated();

        if (!IsAuthenticated)
        {
            await _navigationService.NavigateAsync(NavigationConstants.Login);
        }
    }

    private void OnLoginSucceeded()
    {
        IsAuthenticated = _authenticationService.IsUserAuthenticated();
        Greeting = "Yo!";
    }

    // ToDo: Subscribe to message Authentication Succes and update Greeting
    // ToDo: Make IsAuthenticated a property that you can raise => update UI
}
