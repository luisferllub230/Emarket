using E_Market.Core.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface IUsersServices
    {
        Task Add(UsersViewModel uvm);
    }
}
