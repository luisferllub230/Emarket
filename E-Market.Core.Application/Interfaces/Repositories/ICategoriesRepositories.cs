using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Repositories
{
    public interface ICategoriesRepositories
    {
        Task addCategories(Categories ca);
        Task updateCategories(Categories ca);
        Task deleteCategories(Categories ca);
        Task<List<Categories>> getAllCategories();
        Task<Categories> getOneCategories(int id);
    }
}
