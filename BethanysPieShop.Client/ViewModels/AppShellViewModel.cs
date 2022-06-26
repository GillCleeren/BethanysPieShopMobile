using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;

namespace BethanysPieShop.Client.ViewModels;

public class AppShellViewModel : ViewModelBase
{
    private string _greeting;
    private bool _isAuthenticated;

<<<<<<< HEAD
    //private readonly IAuthenticationService _authenticationService;
    private readonly ISettingsService _settingsService;

    public AppShellViewModel(INavigationService navigationService, ISettingsService settingsService)
        : base(navigationService)
    {
        _settingsService = settingsService;
=======
    private readonly IAuthenticationService _authenticationService;
   
    public AppShellViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        : base(navigationService)
    {
        _authenticationService = authenticationService;
>>>>>>> 5b74a9c6ade73fe371ecde49ec28bb1d46afffe5

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
<<<<<<< HEAD
        IsAuthenticated = !string.IsNullOrEmpty(_settingsService.UserIdSetting);
        Greeting = $"Hello, {_settingsService.UserNameSetting}!";
    }
=======
        IsAuthenticated = _authenticationService.IsUserAuthenticated();
        Greeting = "Yo!";
    }

    // ToDo: Subscribe to message Authentication Succes and update Greeting
    // ToDo: Make IsAuthenticated a property that you can raise => update UI
>>>>>>> 5b74a9c6ade73fe371ecde49ec28bb1d46afffe5
}
