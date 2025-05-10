using EasyTravel.Services; // AuthenticationService için gerekli
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthenticationService _authService;

        public AuthController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            bool isValidUser = _authService.CheckUserCredentials(email, password);

            if (isValidUser)
            {
                // Oturum bilgisi ekleme
                HttpContext.Session.SetString("UserEmail", email);

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.ErrorMessage = "E-posta veya şifre hatalı.";
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string email, string password, string fullName, string phoneNumber)
        {
            bool isUserCreated = _authService.CreateNewUser(email, password,fullName,phoneNumber);

            if (isUserCreated)
            {
                return RedirectToAction("Login");
            }

            ViewBag.ErrorMessage = "Kayıt sırasında hata oluştu.";
            return View();
        }
    }
}
