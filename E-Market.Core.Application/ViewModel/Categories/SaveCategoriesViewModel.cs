using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModel.Categories
{
    public class SaveCategoriesViewModel
    {
        public int id { get; set; }
        public string? categoriesName { get; set; }
        public string? categoriesDescrition { get; set; }
    }
}
