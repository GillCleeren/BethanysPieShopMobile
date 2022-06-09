using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Client.ViewModels;

public class AppShellViewModel : ViewModelBase
{
    public AppShellViewModel(INavigationService navigationService)
        : base(navigationService)
    {

    }

    private string _greeting;

    public string Greeting
    {
        get { return _greeting; }
        set { _greeting = value; OnPropertyChanged(); }
    }


    public override void OnAppearing()
    {
        Greeting = "Well, hello there!";
    }
}
