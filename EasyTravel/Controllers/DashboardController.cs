using EasyTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http; // Session için gerekli
using System.Linq;
using System;
using EasyTravel.Data;

namespace EasyTravel.Controllers
{
    public class DashboardController : Controller
    {
        private readonly TravelContext _context;

        public DashboardController(TravelContext context)
        {
            _context = context;
        }

        public IActionResult Index()  
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Auth");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var travels = _context.Travels.Include(t => t.Destination).ToList();

            var viewModel = new DashboardPageViewModel
            {
                User = user,
                Travels = travels,
                Search = new SearchModel()
            };

            return View(viewModel); // Views/Dashboard/Index.cshtml çağrılır
        }
    }
}
