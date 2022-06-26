using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;

namespace BethanysPieShop.Client.ViewModels;

public class AppShellViewModel : ViewModelBase
{
    private string _greeting;
    private bool _isAuthenticated;

    //private readonly IAuthenticationService _authenticationService;
    private readonly ISettingsService _settingsService;

    public AppShellViewModel(INavigationService navigationService, ISettingsService settingsService)
        : base(navigationService)
    {
        _settingsService = settingsService;

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
        IsAuthenticated = !string.IsNullOrEmpty(_settingsService.UserIdSetting);

        if (!IsAuthenticated)
        {
            await _navigationService.NavigateAsync(NavigationConstants.Login);
        }
        else
        {
            await _navigationService.NavigateAsync(NavigationConstants.Home);
        }
    }

    private void OnLoginSucceeded()
    {
        IsAuthenticated = !string.IsNullOrEmpty(_settingsService.UserIdSetting);
        Greeting = $"Hello, {_settingsService.UserNameSetting}!";
    }
}
