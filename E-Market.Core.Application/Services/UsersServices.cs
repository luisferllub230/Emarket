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


        public async Task<bool> confirmUsersName(SaveUsersViewModel suvm) 
        {
            if (await _user.getByString(suvm.UserName)) 
            {
                return true;
            }

            return false;
        }

        public async Task<UsersViewModel>  Logging(UsersLoggingViewModel suvm)
        {
            Users us = await _user.logging(suvm);

            if (us == null) 
            {
                return null;
            }

            UsersViewModel user = new();
            user.UserName = us.UserName;
            user.Name = us.Name;
            user.UserLastName = us.UserLastName;
            user.UsersPhone = us.UsersPhone;
            user.UserEmail = us.UserEmail;
            user.UsersPasswork = us.UsersPasswork;
            

            return user;
        }

        public async Task Add(SaveUsersViewModel suvm)
        {
            Users user = new();
            user.UserName = suvm.UserName;
            user.Name = suvm.Name;
            user.UserLastName = suvm.UserLastName;
            user.UsersPhone = suvm.UsersPhone;
            user.UserEmail = suvm.UserEmail;
            user.UsersPasswork = suvm.UsersPasswork;
            await _user.add(user);
        }

        public async Task Update(SaveUsersViewModel suvm)
        {
            Users user = new();
            user.id = suvm.id;
            user.UserName = suvm.UserName;
            user.UserLastName = suvm.UserLastName;
            user.UsersPhone = suvm.UsersPhone;
            user.UserEmail = suvm.UserEmail;
            user.UsersPasswork = suvm.UsersPasswork;
            await _user.update(user);
        }

        public async Task<List<UsersViewModel>> GetAll()
        {
            var userList = await _user.getAllByInclude(new List<string> { "comercials" });

            return userList.Select(c => new UsersViewModel
            {
                id = c.id,

                UserName = c.UserName,
                UserLastName = c.UserLastName,
                UsersPhone = c.UsersPhone,
                UserEmail = c.UserEmail,
                UsersPasswork = c.UsersPasswork,

            }).ToList();
        }

        public async Task<SaveUsersViewModel> GetById(int id)
        {
            var user = await _user.getOne(id);

            SaveUsersViewModel suvm = new();
            suvm.id = user.id;
            suvm.UserName = user.UserName;
            suvm.UserLastName = user.UserLastName;
            suvm.UsersPhone = user.UsersPhone;
            suvm.UsersPasswork = user.UsersPasswork;

            return suvm;
        }

        public async Task Delete(SaveUsersViewModel suvm)
        {
            var user = await _user.getOne(suvm.id);
            await _user.delete(user);
        }
    }
}
