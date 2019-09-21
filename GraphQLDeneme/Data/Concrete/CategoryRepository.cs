using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDeneme.Models;

namespace GraphQLDeneme.Data.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>{
                new Category()
                {
                    Id = 1,
                    Name = "Computers"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Mobile Phones"
                }
            };
        }

        public Task<List<Category>> GetAllAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<Category> GetByIdAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(x=> x.Id == id));
        }
    }
}
