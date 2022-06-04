using BethanysPieShop.Client.ViewModels;
using System.Diagnostics;

namespace BethanysPieShop.Client.Views;

public partial class PieCatalogView : ContentPage
{
    private readonly PieCatalogViewModel _viewModel;
    
    public PieCatalogView(PieCatalogViewModel viewModel)
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