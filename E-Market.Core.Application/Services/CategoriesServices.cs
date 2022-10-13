using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private ICategoriesRepositories _ca;

        public CategoriesServices(ICategoriesRepositories a) 
        {
            _ca = a;
        }

        public async Task Add(CategoriesViewModel cavm)
        {
            Categories ca = new();
            ca.categoriesName = cavm.categoriesName;
            ca.categoriesDescrition = cavm.categoriesDescrition;
            await _ca.addCategories(ca);
        }

        public async Task<List<CategoriesViewModel>> GetAllCategories()
        {
            var caList = await _ca.getAllCategories();
            return caList.Select(c => new CategoriesViewModel {
                id = c.id,
                categoriesName = c.categoriesName,
                categoriesDescrition = c.categoriesDescrition,
                comercials = c.comercials
            }).ToList();
        }
    }
}
