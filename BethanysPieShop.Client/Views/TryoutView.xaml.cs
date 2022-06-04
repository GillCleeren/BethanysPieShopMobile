using BethanysPieShop.Client.ViewModels;
using System.Diagnostics;

namespace BethanysPieShop.Client.Views;

public partial class TryoutView : ContentPage
{
	public TryoutView(TryoutViewModel _vm)
	{
		InitializeComponent();
		Debug.WriteLine($"VM: {_vm}");
		BindingContext = _vm;
	}
}