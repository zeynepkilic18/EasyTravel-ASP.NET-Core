using EasyTravel.Data;
using EasyTravel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelContext _context;

        public HomeController(TravelContext context)
        {
            _context = context;
            
        }
        

        public async Task<IActionResult> Index()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            // Eğer oturumda email varsa, kullanıcı giriş yapmış
            if (!string.IsNullOrEmpty(email))
            {
                ViewBag.UserEmail = email; 
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            var travels = await _context.Travels.Include(t => t.Destination).ToListAsync();

            var homePageViewModel = new DashboardPageViewModel

            {
                Travels = travels,  
                Search = new SearchModel(), 
                User = user 
            };

            return View(homePageViewModel); // Home/Index.cshtml'e DashboardPageViewModel gönderiyoruz
        }
    }
}
