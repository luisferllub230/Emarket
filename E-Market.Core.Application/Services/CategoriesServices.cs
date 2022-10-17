using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
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

        public async Task Add(SaveCategoriesViewModel cavm)
        {
            Categories ca = new();
            ca.categoriesName = cavm.categoriesName;
            ca.categoriesDescrition = cavm.categoriesDescrition;
            await _ca.add(ca);
        }

        public async Task Update(SaveCategoriesViewModel cavm)
        {
            Categories ca = new();
            ca.id = cavm.id;
            ca.categoriesName = cavm.categoriesName;
            ca.categoriesDescrition = cavm.categoriesDescrition;
            await _ca.update(ca);
        }

        public async Task<List<CategoriesViewModel>> GetAll()
        {
            var caList = await _ca.getAllByInclude(new List<string> { "comercials" });
            return caList.Select(c => new CategoriesViewModel {
                id = c.id,
                categoriesName = c.categoriesName,
                categoriesDescrition = c.categoriesDescrition,
                comercialCount = c.comercials.Count(),
                comercials = c.comercials,
            }).ToList();
        }

        public async Task<SaveCategoriesViewModel> GetById(int id)
        {
            var category = await _ca.getOne(id);

            SaveCategoriesViewModel scvm = new();
            scvm.id = category.id;
            scvm.categoriesName = category.categoriesName;
            scvm.categoriesDescrition = category.categoriesDescrition;

            return scvm;
        }

        public async Task Delete(SaveCategoriesViewModel cavm)
        {
            var category = await _ca.getOne(cavm.id);
            await _ca.delete(category);
        }
    }
}
