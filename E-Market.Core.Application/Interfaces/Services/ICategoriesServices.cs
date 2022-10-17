using E_Market.Core.Application.ViewModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface ICategoriesServices : IGenericServices<CategoriesViewModel, SaveCategoriesViewModel>{}
}
