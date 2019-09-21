using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDeneme.Data
{
    public interface IRepository<T> where T : new()
    {
      
    }

    public interface ICommandRepository<T> where T : new()
    {
        T Add(T entity);
        T Update(T entity);
        T DeleteById(int id);
    }

    public interface IQueryRepository<T> where T : new()
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
