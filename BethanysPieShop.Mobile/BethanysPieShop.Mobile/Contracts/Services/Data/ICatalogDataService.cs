using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShop.Mobile.Core.Models;

namespace BethanysPieShop.Mobile.Core.Contracts.Services.Data
{
    public interface ICatalogDataService
    {
        Task<IEnumerable<Pie>> GetAllPiesAsync();
        Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync();
    }
}
