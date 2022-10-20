using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Core.Application.ViewModel.Users;
using Microsoft.AspNetCore.Mvc;
using E_Market.Core.Application.Helper;
using E_Market.Midelware;

namespace E_Market.Controllers
{
    public class UsersController : Controller
    {

        private IUsersServices _user;
        private readonly UserSessionValidationcs _userSessionValidations;

        public UsersController(IUsersServices iuser, UserSessionValidationcs us)
        {
            _user = iuser;
            _userSessionValidations = us;
        }

        //logging
        public async Task<IActionResult> logging()
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> logging(UsersLoggingViewModel uvm)
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid) 
            {
                return View(uvm);
            }

            UsersViewModel userVm = await _user.Logging(uvm);

            if (userVm != null)
            {
                HttpContext.Session.set<UsersViewModel>("user",userVm);//create session
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "UserName or password wrong");
            }

            return View(uvm);
        }

        //register
        public async Task<IActionResult> UserRegister()
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new SaveUsersViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(SaveUsersViewModel suvm)
        {
            if (_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            //for validate the form
            if (!ModelState.IsValid)
            {
                return View(suvm);
            }

            //for validate the user name
            if (!await _user.confirmUsersName(suvm)) 
            {
                ViewBag.validator = true;
                return View(suvm);
            }
            
            await _user.Add(suvm);
            return RedirectToRoute(new { controller="Users", action= "logging" });
        }
    }
}
