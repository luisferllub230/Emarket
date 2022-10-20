using E_Market.Core.Application.Helper;
using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Core.Application.ViewModel.Comercials;
using E_Market.Core.Application.ViewModel.Users;
using E_Market.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Services
{
    public class ComercialService : IComercialServices
    {
        private IComercialRepositories _IcomercialR;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UsersViewModel _userViewModel;

        public ComercialService(IComercialRepositories cr, IHttpContextAccessor ca) 
        {
            _IcomercialR = cr;
            _contextAccessor = ca;
            _userViewModel = _contextAccessor.HttpContext.Session.get<UsersViewModel>("user");
        }

        public async Task<SaveComercialViewModel> Add(SaveComercialViewModel c)
        {
            //DateTime nowDateTime = DateTime.Now;
            Comercial co = new();
            co.comercialName = c.comercialName;
            co.comercialImage1 = c.comercialImage1;
            co.comercialImage2 = c.comercialImage2;
            co.comercialImage3 = c.comercialImage3;
            co.comercialImage4 = c.comercialImage4;
            co.comercialCategoriesID = c.comercialCategoriesID;
            co.comercialDesciption = c.comercialDesciption;
            co.price = c.price;
            co.comercialUsersID = _userViewModel.id;
            co.comercialDate = DateTime.Now;

            co = await _IcomercialR.add(co);

            SaveComercialViewModel sc = new SaveComercialViewModel();
            sc.id = co.id;   
            sc.comercialName = co.comercialName;
            sc.comercialImage1 = co.comercialImage1;
            sc.comercialImage2 = co.comercialImage2;
            sc.comercialImage3 = co.comercialImage3;
            sc.comercialImage4 = co.comercialImage4;
            sc.comercialCategoriesID = co.comercialCategoriesID;
            sc.comercialDesciption = co.comercialDesciption;
            sc.price = co.price;
            sc.comercialDate = co.comercialDate;

            return sc;
        }




        public async Task Update(SaveComercialViewModel c)
        {
            Comercial ca = await _IcomercialR.getOne(c.id);
            ca.id = c.id;
            ca.comercialName = c.comercialName;
            ca.comercialDate = c.comercialDate;
            ca.comercialImage1 = c.comercialImage1;
            ca.comercialImage2 = c.comercialImage2;
            ca.comercialImage3 = c.comercialImage3;
            ca.comercialImage4 = c.comercialImage4;
            ca.comercialCategoriesID = c.comercialCategoriesID;
            ca.comercialDesciption = c.comercialDesciption;
            ca.price = c.price;
            ca.comercialUsersID = _userViewModel.id;

            await _IcomercialR.update(ca);
        }

        public async Task<List<ComercialViewModel>> GetAll()
        {
            var comercialList = await _IcomercialR.getAll();
            return comercialList.Where(c => c.comercialUsersID == _userViewModel.id).Select(c => new ComercialViewModel
            {
                id = c.id,
                comercialName = c.comercialName,
                comercialDate = c.comercialDate,
                comercialImage1 = c.comercialImage1,
                comercialImage2 = c.comercialImage2,
                comercialImage3 = c.comercialImage3,
                comercialImage4 = c.comercialImage4,
                comercialCategoriesID = c.comercialCategoriesID,
                comercialDesciption = c.comercialDesciption,
                comercialUserID = _userViewModel.id,
                price = c.price,

            }).ToList();
        }

        public async Task<SaveComercialViewModel> GetById(int id)
        {
            var c = await _IcomercialR.getOne(id);

            SaveComercialViewModel scvm = new();
            scvm.id = c.id;
            scvm.comercialName = c.comercialName;
            scvm.comercialDate = c.comercialDate;
            scvm.comercialImage1 = c.comercialImage1;
            scvm.comercialImage2 = c.comercialImage2;
            scvm.comercialImage3 = c.comercialImage3;
            scvm.comercialImage4 = c.comercialImage4;
            scvm.comercialCategoriesID = c.comercialCategoriesID;
            scvm.comercialDesciption = c.comercialDesciption;
            scvm.price = c.price;

            return scvm;
        }

        public async Task Delete(SaveComercialViewModel cavm)
        {
            var comercial = await _IcomercialR.getOne(cavm.id);
            await _IcomercialR.delete(comercial);
        }
    }
}
