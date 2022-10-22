using E_Market.Core.Application.Helper;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Comercials;
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
        private readonly IComercialServices _cm;
        private readonly ICategoriesServices _categories;
        private readonly IUsersServices _user;

        public HomeController(UserSessionValidationcs us, IComercialServices cm, ICategoriesServices cs, IUsersServices user) 
        {
            _userSessionValidations = us;
            _categories = cs;
            _cm = cm;
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            ViewBag.Categories = await _categories.GetAll();

            return View(await _cm.GetAllExcludingUser());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }


            SaveComercialViewModel cd = await _cm.GetById(id);
            var category = await _categories.GetById(cd.comercialCategoriesID);
            var user = await _user.GetById(cd.comercialUserID);

            cd.categoryName = category.categoriesName;
            cd.userName = user.UserName;
            cd.userEmail = user.UserEmail;
            cd.userPhone = user.UsersPhone;

            return View(cd);
        }


        public IActionResult loguot()
        {
            HttpContext.Session.Remove("user");//delete session
            return RedirectToRoute(new { controller = "Users", action = "logging" });
        }
    }
}