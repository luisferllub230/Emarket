using E_market.Infrastruture.Persistence.Context;
using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_market.Infrastruture.Persistence.Repositories
{
    public class CategoriesRepositories : ICategoriesRepositories
    {

        private readonly ApplicationContext? _contex;


        public CategoriesRepositories(ApplicationContext c)
        {
            _contex = c;
        }

        public async Task addCategories(Categories ca)
        {
            await _contex.Categories.AddAsync(ca);
            await _contex.SaveChangesAsync();
        }

        public async Task deleteCategories(Categories ca)
        {
            _contex.Set<Categories>().Remove(ca);
            await _contex.SaveChangesAsync();
        }

        public async Task<List<Categories>> getAllCategories()
        {
            return await _contex.Set<Categories>().ToListAsync();
        }

        public async Task<Categories> getOneCategories(int id)
        {
            return await _contex.Set<Categories>().FindAsync(id);
        }

        public async Task updateCategories(Categories ca)
        {
            _contex.Entry(ca).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
        }
    }
}
