using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.ViewModels.Base;
using System.Diagnostics;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels
{
    public class TryoutViewModel : ViewModelBase
    {
        int clickCount;

        public TryoutViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            IncrementCommand = new Command(() => ClickCount++);
            PrintPieCommand = new Command<string>(pie => PrintPie(pie));
        }

        public int ClickCount
        {
            get => clickCount;
            set
            {
                clickCount = value;
                OnPropertyChanged(nameof(ClickCount));
            }
        }

        public List<string> Pies
        {
            get
            {
                return new List<string>() { "Apple Pie", "Cherry Pie", "Banana Pie", "Smurfs Pie" };
            }
        }


        public ICommand IncrementCommand { get; }
        public ICommand PrintPieCommand { get; }

        public override void OnAppearing()
        {
            // Nothing to do here
        }

        private void PrintPie(string pie)
        {
            Debug.WriteLine($"Pie: {pie}");
        }
    }
}
