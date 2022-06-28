using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels.Base;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class PieCatalogViewModel : ViewModelBase
{
    private readonly ICatalogDataService _catalogDataService;
    private ObservableCollection<Pie> _pies;

    public PieCatalogViewModel(INavigationService navigationService, ICatalogDataService catalogDataService, IDialogService dialogService)
        : base(navigationService, dialogService)
    {
        _catalogDataService = catalogDataService;
    }

    public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);

    public ObservableCollection<Pie> Pies
    {
        get => _pies;
        set
        {
            _pies = value;
            OnPropertyChanged();
        }
    }

    public async override void OnAppearing()
    {
        Pies = (await _catalogDataService.GetAllPiesAsync()).ToObservableCollection();
    }

    private async void OnPieTapped(Pie pie)
    {
        Debug.WriteLine($"Tapped {pie.Name}");
        await _navigationService.NavigateRelativeAsync(NavigationConstants.PieDetail, pie);
        // Alternative solution:
        // await _navigationService.NavigateAsync(nameof(PieDetailViewModel));
        // use MessagingCenter to send the pie to PieDetailViewModel
    }
}