using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;
using System.Diagnostics;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ISettingsService _settingsService;

    private string _userName;
    private string _password;

    public LoginViewModel(
        ISettingsService settingsService,
        INavigationService navigationService,
        IAuthenticationService authenticationService,
        IDialogService dialogService
        )
        : base(navigationService, dialogService)
    {
        _authenticationService = authenticationService;
        _settingsService = settingsService;
    }

    public ICommand LoginCommand => new Command(OnLogin);

    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public override void OnAppearing()
    {
        // Clear previous user input
        UserName = String.Empty;
        Password = String.Empty;
    }

    private async void OnLogin()
    {
        try
        {
            IsBusy = true;
            var authenticationResponse = await _authenticationService.Authenticate(UserName, Password);

            if (authenticationResponse.IsAuthenticated) 
            {
                // we store the Id to know if the user is already logged in to the application
                _settingsService.UserIdSetting = authenticationResponse.User.Id;
                _settingsService.UserNameSetting = authenticationResponse.User.FirstName;

                IsBusy = false;
                MessagingCenter.Send(this, MessagingConstants.LoginSucceeded);
                await _navigationService.NavigateAsync(NavigationConstants.Home);
            }
            else
            {
                await _dialogService.ShowDialog(
                        "This username/password combination isn't known",
                        "Error logging you in",
                        "OK");
                Debug.WriteLine("This username/password combination isn't known");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
}
