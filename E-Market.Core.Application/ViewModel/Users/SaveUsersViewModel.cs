using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModel.Users
{
    public class SaveUsersViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "please check your User name")]
        [DataType(DataType.Text)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "please check your name")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "please check your last name")]
        [DataType(DataType.Text)]
        public string? UserLastName { get; set; }

        [Required(ErrorMessage = "please check your email")]
        [DataType(DataType.Text)]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "please check your phone number")]
        [DataType(DataType.PhoneNumber)]
        public string? UsersPhone { get; set; }

        [Required(ErrorMessage = "password is Required")]
        [DataType(DataType.Password)]
        public string? UsersPasswork { get; set; }

        [Compare(nameof(UsersPasswork),ErrorMessage = "the password aren't equal")]
        [Required(ErrorMessage = "password is Required")]
        [DataType(DataType.Password)]
        public string? ConfirmUsersPasswork { get; set; }

    }
}
