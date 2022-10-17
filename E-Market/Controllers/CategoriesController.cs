using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using Microsoft.AspNetCore.Mvc;

namespace E_Market.Controllers
{
    public class CategoriesController : Controller
    {

        private ICategoriesServices _ca;

        public CategoriesController(ICategoriesServices ics)
        {
            _ca = ics;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ca.GetAll());
        }

        //create
        public async Task<IActionResult> Create()
        {
            return View("SaveCategories", new SaveCategoriesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoriesViewModel scvm)
        {
            await _ca.Add(scvm);
            return RedirectToRoute(new{ controller="Categories", action ="Index" });
        }

        //edit
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveCategories", await _ca.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveCategoriesViewModel scvm)
        {
            await _ca.Update(scvm);
            return RedirectToRoute(new { controller = "Categories", action = "Index" });
        }

        //delete
        public async Task<IActionResult> Delete(int id) 
        {
            return View(await _ca.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(SaveCategoriesViewModel scvm)
        {
            await _ca.Delete(scvm);
            return RedirectToRoute(new { controller = "Categories", action = "Index" });
        }
    }
}
