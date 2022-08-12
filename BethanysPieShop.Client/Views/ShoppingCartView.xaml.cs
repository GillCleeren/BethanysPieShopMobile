using BethanysPieShop.Client.ViewModels;

namespace BethanysPieShop.Client.Views;

public partial class ShoppingCartView : ContentPage
{
	private readonly ShoppingCartViewModel _viewModel;
	
	public ShoppingCartView(ShoppingCartViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}