using EasyTravel.Data;
using EasyTravel.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache(); // Bellek içi önbellek 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi 30 dakika
});
builder.Services.AddRazorPages(); // Razor Pages desteði 
builder.Services.AddDbContext<TravelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TravelConnection"))); // Veritabaný baðlantýsý
builder.Services.AddScoped<AuthenticationService>(); // AuthenticationService baðýmlýlýðý
builder.Services.AddControllersWithViews(); // MVC'yi etkinleþtir

var app = builder.Build(); // Uygulama örneðini oluþturma

// Uygulamanýn çalýþmasý için gerekli HTTP istek iþleme yapýlandýrmalarýný ekliyoruz
if (!app.Environment.IsDevelopment()) // Eðer uygulama geliþtirme ortamýnda deðilse
{
    app.UseExceptionHandler("/Error"); 
    app.UseHsts(); 
}
app.UseSession();
app.UseHttpsRedirection(); // HTTPS'ye yönlendirme
app.UseStaticFiles(); 
app.UseRouting(); // Yönlendirme (Routing) iþlemleri

app.UseAuthorization(); // Yetkilendirme iþlemleri

// MVC yönlendirmesi
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Destination}/{action=Index}/{id?}");

app.Run(); // Uygulamayý baþlat
