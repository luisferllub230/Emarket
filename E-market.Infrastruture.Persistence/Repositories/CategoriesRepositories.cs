using E_market.Infrastruture.Persistence.Context;
using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_market.Infrastruture.Persistence.Repositories
{
    public class CategoriesRepositories : GeneriesRepositories<Categories>, ICategoriesRepositories
    {

        private readonly ApplicationContext _appContex;

        public CategoriesRepositories(ApplicationContext Dbcontext) : base(Dbcontext)
        {
            _appContex = Dbcontext;
        }

    }
}
