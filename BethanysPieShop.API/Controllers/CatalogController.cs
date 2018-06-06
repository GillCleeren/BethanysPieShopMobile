using System;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CatalogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

            appDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Pies([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var items = await _appDbContext.Pies.OrderBy(p => p.Name).Include(p => p.Category).Skip(pageSize * pageIndex).Take(pageSize)
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> PiesOfTheWeek()
        {
            var items = await _appDbContext.Pies.Where(p => p.IsPieOfTheWeek).OrderBy(p => p.Name)
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet]
        [Route("pies/{id:int}")]
        public async Task<IActionResult> GetPieById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var pie = await _appDbContext.Pies.Where(p => p.PieId == id).SingleOrDefaultAsync();
            if (pie != null)
            {
                return Ok(pie);
            }

            return NotFound();
        }
    }
}
