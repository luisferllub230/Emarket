using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Midelware;
using Microsoft.AspNetCore.Mvc;

namespace E_Market.Controllers
{
    public class CategoriesController : Controller
    {

        private ICategoriesServices _ca;
        private readonly UserSessionValidationcs _userSessionValidations;

        public CategoriesController(ICategoriesServices ics, UserSessionValidationcs us)
        {
            _ca = ics;
            _userSessionValidations = us;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userSessionValidations.hasUser()) 
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            return View(await _ca.GetAll());
        }

        //create
        public async Task<IActionResult> Create()
        {
            if (!_userSessionValidations.hasUser()) 
            { 
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            return View("SaveCategories", new SaveCategoriesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoriesViewModel scvm)
        {
            if (!_userSessionValidations.hasUser()) 
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            await _ca.Add(scvm);
            return RedirectToRoute(new{ controller="Categories", action ="Index" });
        }

        //edit
        public async Task<IActionResult> Edit(int id)
        {
            if (!_userSessionValidations.hasUser()) 
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            return View("SaveCategories", await _ca.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveCategoriesViewModel scvm)
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            await _ca.Update(scvm);
            return RedirectToRoute(new { controller = "Categories", action = "Index" });
        }

        //delete
        public async Task<IActionResult> Delete(int id) 
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            return View(await _ca.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(SaveCategoriesViewModel scvm)
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            await _ca.Delete(scvm);
            return RedirectToRoute(new { controller = "Categories", action = "Index" });
        }
    }
}
