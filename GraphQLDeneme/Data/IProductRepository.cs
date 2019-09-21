using GraphQLDeneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDeneme.Data
{
   public interface IProductRepository : IQueryRepository<Product> , ICommandRepository<Product>
    {   
        Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId);
    }
}
