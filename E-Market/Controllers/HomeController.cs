using E_Market.Core.Application.Helper;
using E_Market.Core.Application.ViewModel.Users;
using E_Market.Core.Domain.Entities;
using E_Market.Midelware;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserSessionValidationcs _userSessionValidations;

        public HomeController(UserSessionValidationcs us) 
        {
            _userSessionValidations = us;
        }

        public IActionResult Index()
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }
            return View();
        }


        public IActionResult loguot()
        {
            HttpContext.Session.Remove("user");//delete session
            return RedirectToRoute(new { controller = "Users", action = "logging" });
        }
    }
}