using Microsoft.AspNetCore.Mvc;
using PortfolioManagement.Domain.Entities.API;
using PortfolioManagement.Infrastructure;

namespace PortfolioManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<CryptoCurrency> _24HourExchangeList = Home.HomeIndex();
            return View(_24HourExchangeList);
        }
    }
}
