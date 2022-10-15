﻿using E_market.Infrastruture.Persistence.Context;
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
    //generies
    public class GeneriesRepositories<Entity> : IGenericRepositories<Entity> where Entity : class 
    {

        private readonly ApplicationContext? _contex;


        public GeneriesRepositories(ApplicationContext c)
        {
            _contex = c;
        }

        public async Task add(Entity entity)
        {
            await _contex.Set<Entity>().AddAsync(entity);
            await _contex.SaveChangesAsync();
        }

        public async Task delete(Entity entity)
        {
            _contex.Set<Entity>().Remove(entity);
            await _contex.SaveChangesAsync();
        }

        public async Task<List<Entity>> getAll()
        {
            return await _contex.Set<Entity>().ToListAsync();
        }

        public async Task<Entity> getOne(int id)
        {
            return await _contex.Set<Entity>().FindAsync(id);
        }

        public async Task update(Entity entity)
        {
            _contex.Entry(entity).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
        }
    }
}