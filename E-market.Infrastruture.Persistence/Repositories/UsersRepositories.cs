using E_market.Infrastruture.Persistence.Context;
using E_Market.Core.Application.Helper;
using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.ViewModel.Users;
using E_Market.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_market.Infrastruture.Persistence.Repositories
{
    public class UsersRepositories : GeneriesRepositories<Users>, IUsersRepositories
    {

        private readonly ApplicationContext _appContex;

        public UsersRepositories(ApplicationContext Dbcontext) : base(Dbcontext)
        {
            _appContex = Dbcontext;
        }

        public override async Task<Users> add(Users entity)
        {
            entity.UsersPasswork = PasswordEncrypted.ComputeSHA256Hash(entity.UsersPasswork);
            return await base.add(entity);
        }

        public async Task<Users> logging(UsersLoggingViewModel entity)
        {
            string psw = PasswordEncrypted.ComputeSHA256Hash(entity.UsersPasswork);
            Users u = await _appContex.Set<Users>().FirstOrDefaultAsync(u => u.UserName == entity.UserName && u.UsersPasswork == psw);
            return u;
        }

        public async Task<bool> getByString(string name)
        {

            Users u = await _appContex.Set<Users>().FirstOrDefaultAsync(u => u.UserName == name);

            if (u != null) 
            {
                if (u.UserName == name) 
                {
                    return false;
                }
            }

            return true;
        }

    }
}
