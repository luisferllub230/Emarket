using E_Market.Core.Application.Interfaces.Services;
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
            return View( await _ca.GetAllCategories());
        }
    }
}
