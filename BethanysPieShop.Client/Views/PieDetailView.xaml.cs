using BethanysPieShop.Client.ViewModels;
using BethanysPieShop.Client.Models;

namespace BethanysPieShop.Client.Views;

public partial class PieDetailView : ContentPage
{
	public PieDetailView()
	{
		InitializeComponent();

		var vm = new PieDetailViewModel();
		var pie = new Pie() { Name = "Apple Pie", Price = 12.95M, ShortDescription = "Our famous apple pies!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", ImageUrl = "applepie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "applepiesmall.jpg", AllergyInformation = "" };
		vm.SelectedPie = pie;
		BindingContext = vm;
	}
}