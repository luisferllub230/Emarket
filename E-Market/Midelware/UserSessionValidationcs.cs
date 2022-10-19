using E_Market.Core.Application.Helper;
using E_Market.Core.Application.ViewModel.Users;
using Microsoft.AspNetCore.Http;

namespace E_Market.Midelware
{
    public class UserSessionValidationcs
    {
        private readonly IHttpContextAccessor _contextAccessor;
        
        public UserSessionValidationcs(IHttpContextAccessor ca) 
        {
            _contextAccessor = ca;
        }

        public bool hasUser() 
        {
            UsersViewModel user = _contextAccessor.HttpContext.Session.get<UsersViewModel>("user");
            if (user == null) 
            {
                return false;
            }

            return true;
        }
    }
}
