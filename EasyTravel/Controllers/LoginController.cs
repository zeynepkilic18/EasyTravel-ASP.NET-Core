
using EasyTravel.Services; // AuthenticationService'e erişim
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthenticationService _authenticationService;

        public LoginController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View(); // Giriş sayfasını döndür
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string email, string password)
        {
            // Kullanıcıyı kontrol etme
            var isAuthenticated = _authenticationService.CheckUserCredentials(email, password);

            if (isAuthenticated)
            {
                // Başarılı giriş
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Hatalı giriş
                ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
                return View(); 
            }
        }
    }
}
