using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Domain.Entities
{
    public class Users
    {
        public int id { get; set; }
        public string? UserName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserEmail { get; set; }
        public string? UsersPhone { get; set; }
        public string? UsersPasswork { get; set; }

        public ICollection<Comercial>? comercials { get; set; }
    }
}
