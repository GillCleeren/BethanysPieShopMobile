using BethanysPieShop.Client.ViewModels;

namespace BethanysPieShop.Client.Views;

public partial class LoginView : ContentPage
{
	private readonly LoginViewModel _viewModel;
	public LoginView(LoginViewModel loginViewModel)
	{
		InitializeComponent();

		_viewModel = loginViewModel;
		BindingContext = _viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

	}
}