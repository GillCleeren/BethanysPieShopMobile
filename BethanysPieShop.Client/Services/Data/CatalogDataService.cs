using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Repository;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Client.Services.Data;

public class CatalogDataService : ICatalogDataService
{
    private readonly IGenericRepository _genericRepository;

    public CatalogDataService(IGenericRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<IEnumerable<Pie>> GetAllPiesAsync()
    {
        UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        {
            Path = ApiConstants.CatalogEndpoint
        };

        var pies = await _genericRepository.GetAsync<List<Pie>>(builder.ToString());
        return pies;
    }

    public async Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync()
    {
        UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        {
            Path = ApiConstants.PiesOfTheWeekEndpoint
        };

        var pies = await _genericRepository.GetAsync<List<Pie>>(builder.ToString());

        return pies;
    }
}
