using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepositories<Entity> where Entity : class
    {
        Task add(Entity entity);
        Task delete(Entity entity);
        Task<List<Entity>> getAll();
        Task<Entity> getOne(int id);
        Task update(Entity entity);
        Task<List<Entity>> getAllByInclude(List<string> properties);
    }
}
