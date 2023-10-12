namespace BethanysPieShop.Client.Contracts.Services.General;

public interface IDialogService
{
    Task ShowDialog(string message, string title, string buttonLabel);

    Task ShowToast(string message);
}
