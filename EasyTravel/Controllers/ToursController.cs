using EasyTravel.Data;
using EasyTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EasyTravel.Controllers
{
    public class ToursController : Controller
    {
        private readonly TravelContext _context;

        public ToursController(TravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _context.Tours.ToListAsync();
            return View(tours);
        }
    }
}
