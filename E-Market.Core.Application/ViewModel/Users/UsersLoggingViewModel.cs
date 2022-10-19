using System.ComponentModel.DataAnnotations;

namespace E_Market.Core.Application.ViewModel.Users
{
    public class UsersLoggingViewModel
    {
        [Required(ErrorMessage = "please check your name")]
        [DataType(DataType.Text)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "password is Required")]
        [DataType(DataType.Password)]
        public string? UsersPasswork { get; set; }
    }
}
