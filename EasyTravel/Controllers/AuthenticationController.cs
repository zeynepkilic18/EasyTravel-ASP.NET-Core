using EasyTravel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EasyTravel.Controllers
{
    [Route("Authentication")]
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationService _authService;

        public AuthenticationController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public JsonResult Login([FromBody] LoginModel model)
        {
            bool isValidUser = _authService.CheckUserCredentials(model.Email, model.Password);

            if (isValidUser)
            {
                HttpContext.Session.SetString("UserEmail", model.Email);
                return Json(new { success = true, message = "Giriş başarılı!" });
            }

            return Json(new { success = false, message = "Hatalı e-posta veya şifre." });
        }

        [HttpPost("Register")]
        public JsonResult Register([FromBody] RegisterModel model)
        {
            bool isUserCreated = _authService.CreateNewUser(model.Email, model.Password, model.FullName, model.PhoneNumber);

            if (isUserCreated)
            {
                return Json(new { success = true, message = "Kayıt başarılı. Giriş yapabilirsiniz." });
            }

            return Json(new { success = false, message = "E-posta zaten kayıtlı." });
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            try
            {
                // Oturumu temizle
                HttpContext.Session.Clear(); 
                                             

                // Giriş yapan kullanıcının bilgilerini sıfırlama 
                HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", "Destination") // Ana sayfaya yönlendirme
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message // Hata mesajı
                });
            }
        }




    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
