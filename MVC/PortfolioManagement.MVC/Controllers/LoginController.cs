using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PortfolioManagement.Application.Abstractions;
using PortfolioManagement.Application.DTOs;

namespace PortfolioManagement.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserAddDto userAddDto)
        {
            await _userService.Add(userAddDto);
            return Redirect("/Portfolio/Index/");
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserDto signInUserDto)
        {
            var result = await _userService.SignInUser(signInUserDto);
            if (result != -1)
            {
                SaveDataWithSession(result);
                return Redirect("/Portfolio/Index/");
            }

            return Redirect("/Home/Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("/Home/Index");

        }

        private void SaveDataWithSession(int result)
        {
            HttpContext.Session.SetInt32("USERNAME", result);

        }
    }
}
