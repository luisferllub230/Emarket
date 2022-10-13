using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Domain.Entities
{
    public class Categories
    {
        public int id { get; set; }
        public string? categoriesName { get; set; }
        public string? categoriesDescrition { get; set; }

        public ICollection<Comercial>? comercials { get; set; }
    }
}
