using E_market.Infrastruture.Persistence.Context;
using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_market.Infrastruture.Persistence.Repositories
{
    public class UsersRepositories : IUsersRepositories
    {

        private readonly ApplicationContext? _contex;


        public UsersRepositories(ApplicationContext c) 
        {
            _contex = c;
        }

        public async Task addUsers(Users u)
        {
            await _contex.Users.AddAsync(u);
            await _contex.SaveChangesAsync();
        }

        public async  Task deleteUsers(Users u)
        {
            _contex.Set<Users>().Remove(u);
            await _contex.SaveChangesAsync();
        }

        public async  Task<List<Users>> getAllUsers()
        {
            return await _contex.Set<Users>().ToListAsync(); 
        }

        public async  Task<Users> getOneUsers(int id)
        {
            return await _contex.Set<Users>().FindAsync(id);       
        }

        public async  Task updateUsers(Users u)
        {
            _contex.Entry(u).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
        }
    }
}
