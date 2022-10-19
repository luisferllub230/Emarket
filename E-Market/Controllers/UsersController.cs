using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Core.Application.ViewModel.Users;
using Microsoft.AspNetCore.Mvc;
using E_Market.Core.Application.Helper;

namespace E_Market.Controllers
{
    public class UsersController : Controller
    {

        private IUsersServices _user;

        public UsersController(IUsersServices iuser)
        {
            _user = iuser;
        }

        //logging
        public async Task<IActionResult> logging()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> logging(UsersLoggingViewModel uvm)
        {
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
            return View(new SaveUsersViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(SaveUsersViewModel suvm)
        {
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
