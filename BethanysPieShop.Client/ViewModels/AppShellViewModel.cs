using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class AppShellViewModel : ViewModelBase
{
    private string _greeting;
    private bool _isAuthenticated;

    private readonly ISettingsService _settingsService;

    public AppShellViewModel(INavigationService navigationService, ISettingsService settingsService, IDialogService dialogService)
        : base(navigationService, dialogService)
    {
        _settingsService = settingsService;
        MessagingCenter.Subscribe<LoginViewModel>(this, MessagingConstants.LoginSucceeded, (loginViewModel) => OnLoginSucceeded());
    }

    public ICommand LogoutCommand => new Command(OnLogout);

    
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
        IsAuthenticated = !string.IsNullOrEmpty(_settingsService.UserIdSetting);

        if (!IsAuthenticated)
        {
            await _navigationService.NavigateAsync(NavigationConstants.Login);
        }
        else
        {
            Greeting = $"Hello, {_settingsService.UserNameSetting}!";
            await _navigationService.NavigateAsync(NavigationConstants.Home);
        }
    }

    private void OnLoginSucceeded()
    {
        IsAuthenticated = !string.IsNullOrEmpty(_settingsService.UserIdSetting);
        Greeting = $"Hello, {_settingsService.UserNameSetting}!";
    }

    private async void OnLogout()
    {
        _settingsService.UserIdSetting = String.Empty;
        _settingsService.UserNameSetting = String.Empty;
        IsAuthenticated = false;
        await _navigationService.NavigateAsync(NavigationConstants.Login);
    }
}
