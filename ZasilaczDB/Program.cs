using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZasilaczDB.Serwisy;
using Zasilacze;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Baza>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Baza") ?? throw new InvalidOperationException("Connection string 'Baza' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IZasilaczSerwis, ZasilaczSerwis>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
