using E_Market.Core.Application.ViewModel.Comercials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface IComercialServices : IGenericServices<ComercialViewModel, SaveComercialViewModel>
    {
        Task<List<ComercialViewModel>> GetAllExcludingUser();
    }
}
