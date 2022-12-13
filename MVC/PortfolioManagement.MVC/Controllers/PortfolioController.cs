using Microsoft.AspNetCore.Mvc;
using System;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using PortfolioManagement.Application.Abstractions;
using PortfolioManagement.Domain.Entities.API;
using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Infrastructure;
using PortfolioManagement.MVC.ViewModels;

namespace PortfolioManagement.MVC.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ITransactionService _transactionService;
        private readonly ICoinWalletService _coinWalletService;
        private readonly PortfolioViewModel _portfolioViewModel;
        public PortfolioController(IPortfolioService portfolioService, PortfolioViewModel portfolioViewModel, ITransactionService transactionService, ICoinWalletService coinWalletService)
        {
            _portfolioService = portfolioService;
            _portfolioViewModel = portfolioViewModel;
            _transactionService = transactionService;
            _coinWalletService = coinWalletService;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> Index()
        {
            var portfolios = await _portfolioService.GetAllUserPortfolios(Convert.ToInt32(HttpContext.Session.GetInt32("USERNAME")));
            if (portfolios != null)
            {
                _portfolioViewModel.UserPortfolioes = portfolios;
            }


            return View(_portfolioViewModel);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Index(int id, bool check)
        {
            HttpContext.Session.SetInt32("PortfolioId", id);
            var portfolios = await _portfolioService.GetUserPortfolio(id);
            if (portfolios != null)
            {
                _portfolioViewModel.UserPortfolioes = portfolios;
            }
            List<CryptoCurrency> _24HourExchangeList = Home.HomeIndex();

            var coinNames = (from i in _24HourExchangeList.ToList()
                             select new SelectListItem
                             {
                                 Text = i.Symbol
                             }).ToList();
            ViewBag.dgr = coinNames;
            _portfolioViewModel.CoinWallets = await _coinWalletService.GetUserWallet(id);

            _portfolioViewModel.CheckPortfolioPartial = check;
            return View(_portfolioViewModel);
        }
        public JsonResult GetCoinName(string id)
        {
            List<CryptoCurrency> _24HourExchangeList = Home.HomeIndex();
            var price = _24HourExchangeList.Where(x => x.Symbol == id).Select(y => y.PrevClosePrice).FirstOrDefault();
            var pricee = System.Text.Json.JsonSerializer.Serialize(price);
            return Json(pricee);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> CreatePortfolio(PortfolioViewModel portPortfolioViewModel)
        {
            portPortfolioViewModel.createPortfolioDto.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("USERNAME"));
            await _portfolioService.AddPortfolio(portPortfolioViewModel.createPortfolioDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BeginTransaction(CreateTransactionDto createTransactionDto)
        {
            var portfolioId = Convert.ToInt32(HttpContext.Session.GetInt32("PortfolioId"));
            createTransactionDto.TransactionType = "Buy";
            var checkAmount = await _transactionService.ManageTransaction(createTransactionDto, portfolioId);
            ViewBag.type = checkAmount;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SellTransaction(CreateTransactionDto createTransactionDto)
        {
            var portfolioId = Convert.ToInt32(HttpContext.Session.GetInt32("PortfolioId"));
            createTransactionDto.TransactionType = "Sell";
            var checkAmount = await _transactionService.ManageTransaction(createTransactionDto, portfolioId);
            ViewBag.type = checkAmount;
            return RedirectToAction("Index");
        }
    }
}
