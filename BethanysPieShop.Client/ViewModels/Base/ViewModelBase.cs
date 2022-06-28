using BethanysPieShop.Client.Contracts.Services.General;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BethanysPieShop.Client.ViewModels.Base;

public abstract class ViewModelBase : INotifyPropertyChanged, IQueryAttributable
{
    //protected readonly IConnectionService _connectionService;
    protected readonly INavigationService _navigationService;
    protected readonly IDialogService _dialogService;

    public ViewModelBase(INavigationService navigationService, IDialogService dialogService)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
    }

    private bool _isBusy;

    public event PropertyChangedEventHandler PropertyChanged;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var data = query["DATA"];
        if (data != null)
        {
            OnNavigatedTo(data);
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void OnNavigatedTo(object data)
    {
        // override if you want to pass data into the VM upon navigation
    }

    public abstract void OnAppearing();
}
