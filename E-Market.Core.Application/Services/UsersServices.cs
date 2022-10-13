using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Services
{
    public class UsersServices : IUsersServices
    {

        private IUsersRepositories _user;

        public UsersServices(IUsersRepositories u) 
        {
            _user = u;
        }

        public async Task Add(UsersViewModel uvm) 
        {
            Users u = new();
            u.UserName = uvm.UserName;
            u.UserLastName = uvm.UserLastName;
            u.UserEmail = uvm.UserEmail;
            u.UsersPhone = uvm.UsersPhone;
            u.UsersPasswork = uvm.UsersPasswork;
            await _user.addUsers(u);
        }

        
    }
}
