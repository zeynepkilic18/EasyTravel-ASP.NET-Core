using EasyTravel.Data; // TravelContext'e erişim
using EasyTravel.Models; // User modele erişim
using BCrypt.Net; // BCrypt.Net kütüphanesini kullanabilmek için

namespace EasyTravel.Services
{
    public class AuthenticationService
    {
        private readonly TravelContext _context;

        public AuthenticationService(TravelContext context)
        {
            _context = context;
        }

        // Kullanıcı giriş kontrolü 
        public bool CheckUserCredentials(string email, string password)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);

                if (user != null)
                {
                    Console.WriteLine($"Hashli şifre: {user.Password}");
                    Console.WriteLine($"Girişteki şifre: {password}");

                    // Şifrenin doğrulanması
                    bool passwordIsValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

                    if (passwordIsValid)
                    {
                        return true; 
                    }
                    else
                    {
                        // Hatalı şifre
                        Console.WriteLine("Hatalı şifre girdiniz");
                    }
                }
                else
                {
                    // Kullanıcı bulunamadı
                    Console.WriteLine("Kullanıcı bulunamadı");
                }

                return false; 
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // Hatalı hash formatı
                Console.WriteLine("Şifre doğrulama hatası: Salt versiyonu hatalı");
                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Beklenmeyen bir hata oluştu: {ex.Message}");
                return false;
            }
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }


        // Yeni kullanıcı oluşturma 
        public bool CreateNewUser(string email, string password, string fullName,string phoneNumber)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return false; // Kullanıcı zaten mevcut
            }

            // Şifreyi hashleme
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User
            {
                Email = email,
                Password = hashedPassword,
                FullName = fullName,
                PhoneNumber = phoneNumber
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return true;
        }
    }
}
