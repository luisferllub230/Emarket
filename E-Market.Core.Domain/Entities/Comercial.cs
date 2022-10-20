using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Domain.Entities
{
    public class Comercial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? comercialName { get; set; } 
        public string? comercialDesciption {get; set; }
        public string? comercialImage1 { get; set; }
        public string? comercialImage2 { get; set; }
        public string? comercialImage3 { get; set; }
        public string? comercialImage4 { get; set; }
        public DateTime comercialDate { get; set; }
        public int comercialCategoriesID { get; set; }
        public int comercialUsersID { get; set; }
        public float price { get; set; }

        [ForeignKey("comercialCategoriesID")]
        public virtual Categories? comercialCategories { get; set; }


        [ForeignKey("comercialUsersID")]
        public virtual Users? comercialUsers { get; set; }
    }
}
