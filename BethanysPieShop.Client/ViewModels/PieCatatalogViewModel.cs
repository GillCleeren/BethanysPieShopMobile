using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Extensions;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class PieCatalogViewModel : ViewModelBase
{
    private readonly ICatalogDataService _catalogDataService;
    private ObservableCollection<Pie> _pies;

    public async void OnAppearing()
    {
        Pies = (await _catalogDataService.GetAllPiesAsync()).ToObservableCollection();
    }

    public PieCatalogViewModel(ICatalogDataService catalogDataService)
        : base()
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

    private void OnPieTapped(Pie pie)
    {
        Debug.WriteLine($"Tapped {pie}");
        //_navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
    }
}