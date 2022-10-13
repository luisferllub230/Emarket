using E_Market.Core.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface ICategoriesServices
    {
        Task Add(CategoriesViewModel cavm);
        Task<List<CategoriesViewModel>> GetAllCategories();
    }
}
