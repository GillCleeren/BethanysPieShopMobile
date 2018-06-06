using Acr.UserDialogs;
using BethanysPieShop.Mobile.Core.Contracts.Services.General;
using System.Threading.Tasks;

namespace BethanysPieShop.Mobile.Core.Services.General
{
    public class DialogService : IDialogService
    {
        public Task ShowDialog(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public void ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
    }
}
