using BethanysPieShop.Client.ViewModels;

namespace BethanysPieShop.Client.Views;

public partial class PieDetailView : ContentPage
{
	public PieDetailView(PieDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}