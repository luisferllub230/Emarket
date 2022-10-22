using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Core.Application.ViewModel.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModel.Comercials
{
    public class SaveComercialViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "please check your comercial name")]
        [DataType(DataType.Text)]
        public string? comercialName { get; set; }

        [Required(ErrorMessage = "please check your comercial description")]
        [DataType(DataType.Text)]
        public string? comercialDesciption { get; set; }


        public string? comercialImage1 { get; set; }
        public string? comercialImage2 { get; set; }
        public string? comercialImage3 { get; set; }
        public string? comercialImage4 { get; set; }

        public DateTime comercialDate { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = "please check your comercial price")]
        public float price { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = "please check your comercial categorie")]
        public int comercialCategoriesID { get; set; }

        public int comercialUserID { get; set; }

        public List<CategoriesViewModel> categories { get; set; }
        public List<UsersViewModel> user { get; set; }

        public string categoryName { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }


        [DataType(DataType.Upload)]
        public IFormFile file1 { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile file2 { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile file3 { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile file4 { get; set; }

    }
}
