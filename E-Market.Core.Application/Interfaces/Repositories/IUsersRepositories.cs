using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Repositories
{
    public interface IUsersRepositories
    {
        Task addUsers(Users u);
        Task updateUsers(Users u);
        Task deleteUsers(Users u);
        Task<List<Users>> getAllUsers();
        Task<Users> getOneUsers(int id);
    }
}
