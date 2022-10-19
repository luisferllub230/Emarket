﻿using E_Market.Core.Application.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface IUsersServices : IGenericServices<UsersViewModel, SaveUsersViewModel>
    {
        Task<bool> confirmUsersName(SaveUsersViewModel suvm);
        Task<UsersViewModel> Logging(UsersLoggingViewModel suvm);
    }
}
