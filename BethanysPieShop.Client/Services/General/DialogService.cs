using BethanysPieShop.Client.Contracts.Services.General;

namespace BethanysPieShop.Client.Services.General;

public class DialogService : IDialogService
{
    public Task ShowDialog(string message, string title, string buttonLabel)
    {
        return App.Current.MainPage.DisplayAlert(title, message, buttonLabel);
    }

    public Task ShowToast(string message)
    {
        throw new NotImplementedException();
    }
}
