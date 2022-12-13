using PortfolioManagement.Application.Services;
using PortfolioManagement.MVC.ViewModels;
using PortfolioManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.RegisterServices();
builder.Services.AddScoped<PortfolioViewModel, PortfolioViewModel>();
builder.Services.AddSingleton<BinanceService>();
builder.Services.AddSession();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
