namespace BethanysPieShop.Client.Contracts.Services.General;

public interface INavigationService
{
    Task NavigateAsync(string routeName);
    Task NavigateRelativeAsync(string routeName, object parameter);
}
