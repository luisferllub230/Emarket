using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Core.Application.ViewModel.Users;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> logging(UsersViewModel uvm)
        {
            if (!ModelState.IsValid) 
            {
                return View(uvm);
            }

            return View();
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
