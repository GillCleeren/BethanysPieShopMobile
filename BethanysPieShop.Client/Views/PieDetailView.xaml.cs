using BethanysPieShop.Client.ViewModels;
using BethanysPieShop.Client.Models;

namespace BethanysPieShop.Client.Views;

public partial class PieDetailView : ContentPage
{
	public PieDetailView(PieDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}