﻿using E_market.Infrastruture.Persistence.Context;
using E_market.Infrastruture.Persistence.Repositories;
using E_Market.Core.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            #region context
            //for run database in memory 
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<ApplicationContext>(o => o.UseInMemoryDatabase("applicationDB"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConection")
                    , m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion

            #region repositories
            services.AddTransient<IUsersRepositories, UsersRepositories>();
            services.AddTransient<ICategoriesRepositories, CategoriesRepositories>();
            //services.AddTransient<IPokemonTypesRepository, PokemonsTypesRepositore>();
            #endregion
        }
    }
}
