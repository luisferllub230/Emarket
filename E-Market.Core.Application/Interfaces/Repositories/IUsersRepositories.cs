using E_Market.Core.Application.ViewModel.Users;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Repositories
{
    public interface IUsersRepositories : IGenericRepositories<Users>
    {
        Task<bool> getByString(string name);
        Task<Users> logging(UsersLoggingViewModel entity);
    }
}
