using E_Market.Core.Application.Helper;
using E_Market.Core.Application.ViewModel.Users;
using E_Market.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Market.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult loguot()
        {
            HttpContext.Session.Remove("user");//delete session
            return RedirectToRoute(new { controller = "Users", action = "logging" });
        }
    }
}