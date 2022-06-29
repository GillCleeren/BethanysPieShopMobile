using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels.Base;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class PieDetailViewModel : ViewModelBase
{
    private Pie _selectedPie;

    public PieDetailViewModel(INavigationService navigationService, IDialogService dialogService)
        :base(navigationService, dialogService)
    {
        
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

    private async void OnAddToCart()
    {
        MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, SelectedPie);
        await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
    }

    private void OnReadDescription()
    {
        //DependencyService.Get<ITextToSpeech>().ReadText(SelectedPie.LongDescription);
    }
}
