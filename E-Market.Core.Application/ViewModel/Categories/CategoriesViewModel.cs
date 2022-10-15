using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModel.Categories
{
    public class CategoriesViewModel
    {
        public int id { get; set; }
        public string? categoriesName { get; set; }
        public string? categoriesDescrition { get; set; }

        public int comercialCount { get; set; }
        public int userComercialCount { get; set; }
    }
}
