using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Client.ViewModels.Base;

public class ViewModelBase : INotifyPropertyChanged
{
    //protected readonly IConnectionService _connectionService;
    //protected readonly INavigationService _navigationService;
    //protected readonly IDialogService _dialogService;

    //public ViewModelBase(IConnectionService connectionService, INavigationService navigationService,
    //    IDialogService dialogService)
    //{
    //    _connectionService = connectionService;
    //    _navigationService = navigationService;
    //    _dialogService = dialogService;
    //}

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

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual Task InitializeAsync(object data)
    {
        return Task.FromResult(false);
    }
}
