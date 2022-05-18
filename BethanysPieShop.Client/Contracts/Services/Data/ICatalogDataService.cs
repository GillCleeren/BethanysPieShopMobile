using BethanysPieShop.Client.Models;

namespace BethanysPieShop.Client.Contracts.Services.Data;

public interface ICatalogDataService
{
    Task<IEnumerable<Pie>> GetAllPiesAsync();
    Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync();
}