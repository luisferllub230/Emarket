using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Core.Application.ViewModel.Users;
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
            await _user.add(u);
        }

        public Task Add(SaveUsersViewModel cavm)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(SaveUsersViewModel cavm)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsersViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SaveUsersViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SaveUsersViewModel cavm)
        {
            throw new NotImplementedException();
        }
    }
}
