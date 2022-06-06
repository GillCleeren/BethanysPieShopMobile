using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels.Base;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class PieDetailViewModel : ViewModelBase
{
    private Pie _selectedPie;

    //public PieDetailViewModel(IConnectionService connectionService,
    //    INavigationService navigationService, IDialogService dialogService)
    //    : base(connectionService, navigationService, dialogService)
    //{ }

    public PieDetailViewModel(INavigationService navigationService)
        :base(navigationService)
    {
        //var pie = new Pie() { Name = "Apple Pie", Price = 12.95M, ShortDescription = "Our famous apple pies!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", ImageUrl = "applepie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "applepiesmall.jpg", AllergyInformation = "" };
        //SelectedPie = pie;
    }

    public ICommand AddToCartCommand => new Command(OnAddToCart);
    public ICommand ReadDescriptionCommand => new Command(OnReadDescription);

    protected override void OnNavigatedTo(object data)
    {
        SelectedPie = data as Pie;
    }

    public Pie SelectedPie
    {
        get => _selectedPie;
        set
        {
            _selectedPie = value;
            OnPropertyChanged();
        }
    }

    public override async Task InitializeAsync(object data)
    {
        SelectedPie = (Pie)data;
    }

    private async void OnAddToCart()
    {
        //MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, SelectedPie);
        //await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
    }

    private void OnReadDescription()
    {
        //DependencyService.Get<ITextToSpeech>().ReadText(SelectedPie.LongDescription);
    }
}
