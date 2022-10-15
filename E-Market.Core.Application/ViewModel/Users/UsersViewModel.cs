using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModel.Users
{
    public class UsersViewModel
    {
        public int id { get; set; }
        public string? UserName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserEmail { get; set; }
        public string? UsersPhone { get; set; }
        public string? UsersPasswork { get; set; }
    }
}
