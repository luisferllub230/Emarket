using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Domain.Entities
{
    public class Comercial
    {
        public int id { get; set; }
        public string? comercialName { get; set; } 
        public string? comercialDesciption {get; set; }
        public string? comercialImage1 { get; set; }
        public string? comercialImage2 { get; set; }
        public string? comercialImage3 { get; set; }
        public string? comercialImage4 { get; set; }
        public DateTime comercialDate { get; set; }

        public int comercialCategoriesID { get; set; }
        public Categories? comercialCategories { get; set; }

        public int comercialUsersID { get; set; }
        public Users? comercialUsers { get; set; }
    }
}
