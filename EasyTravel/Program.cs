using EasyTravel.Data;
using EasyTravel.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache(); // Bellek i�i �nbellek 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum s�resi 30 dakika
});
builder.Services.AddRazorPages(); // Razor Pages deste�i 
builder.Services.AddDbContext<TravelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TravelConnection"))); // Veritaban� ba�lant�s�
builder.Services.AddScoped<AuthenticationService>(); // AuthenticationService ba��ml�l���
builder.Services.AddControllersWithViews(); // MVC'yi etkinle�tir

var app = builder.Build(); // Uygulama �rne�ini olu�turma

// Uygulaman�n �al��mas� i�in gerekli HTTP istek i�leme yap�land�rmalar�n� ekliyoruz
if (!app.Environment.IsDevelopment()) // E�er uygulama geli�tirme ortam�nda de�ilse
{
    app.UseExceptionHandler("/Error"); 
    app.UseHsts(); 
}
app.UseSession();
app.UseHttpsRedirection(); // HTTPS'ye y�nlendirme
app.UseStaticFiles(); 
app.UseRouting(); // Y�nlendirme (Routing) i�lemleri

app.UseAuthorization(); // Yetkilendirme i�lemleri

// MVC y�nlendirmesi
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Destination}/{action=Index}/{id?}");

app.Run(); // Uygulamay� ba�lat
