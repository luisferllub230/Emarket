using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.Services;
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
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region repositories
            services.AddTransient<IUsersServices, UsersServices>();
            services.AddTransient<ICategoriesServices, CategoriesServices>();
            #endregion
        }
    }
}
