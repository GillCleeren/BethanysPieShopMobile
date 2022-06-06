using BethanysPieShop.Client.Contracts.Services.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Client.Services.General
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateAsync(string routeName)
        {
            await Shell.Current.GoToAsync($"//{routeName}");
        }

        public async Task NavigateRelativeAsync(string routeName, object parameter)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "DATA", parameter }
            };

            await Shell.Current.GoToAsync($"{routeName}", navigationParameter);
        }
    }
}
