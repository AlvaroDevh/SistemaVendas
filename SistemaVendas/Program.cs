using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SistemaVendas.Data;
using SistemaVendas.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionStr = "Server=(localdb)\\mssqllocaldb;Database=SistemaVendasContext-dd8a12b5-18e7-4bf1-8057-3f04bb11b7e6;Trusted_Connection=True;MultipleActiveResultSets=true";
builder.Services.AddDbContext<SistemaVendasContext>(options =>
    options.UseSqlServer(connectionStr));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
