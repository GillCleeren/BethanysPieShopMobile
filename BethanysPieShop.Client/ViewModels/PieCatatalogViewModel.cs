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

    public ICommand LoadPiesCommand { get; }

    public async void OnAppearing()
    {
        //IsBusy = true;
        Pies = (await _catalogDataService.GetAllPiesAsync()).ToObservableCollection();
    }

    public PieCatalogViewModel(ICatalogDataService catalogDataService)
        : base()
    {
        _catalogDataService = catalogDataService;
        LoadPiesCommand = new Command(async () => await ExecuteLoadPiesCommand());
        //_pies = new ObservableCollection<Pie>();
        //var pie = new Pie() { Name = "Apple Pie", Price = 12.95M, ShortDescription = "Our famous apple pies!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", ImageUrl = "applepie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "applepiesmall.jpg", AllergyInformation = "" };
        //_pies.Add(pie);
    }

    private async Task ExecuteLoadPiesCommand()
    {
        IsBusy = true;

        Pies = (await _catalogDataService.GetAllPiesAsync()).ToObservableCollection();

        IsBusy = false;
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

    private void OnPieTapped(Pie selectedPie)
    {
        //_navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
    }
}