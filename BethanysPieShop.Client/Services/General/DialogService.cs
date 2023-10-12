using BethanysPieShop.Client.Contracts.Services.General;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace BethanysPieShop.Client.Services.General;

public class DialogService : IDialogService
{
    public Task ShowDialog(string message, string title, string buttonLabel)
    {
        return App.Current.MainPage.DisplayAlert(title, message, buttonLabel);
    }

    public Task ShowToast(string message)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        string text = message;
        ToastDuration duration = ToastDuration.Long;
        double fontSize = 14;

        var toast = Toast.Make(text, duration, fontSize);

        return toast.Show(cancellationTokenSource.Token);
    }
}
