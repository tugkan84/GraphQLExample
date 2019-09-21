using GraphQL.Types;
using GraphQLDeneme.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDeneme.Models.GraphQLModels
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository)
        {
            Field(x => x.Id).Description("Product id.");
            Field(x => x.Name).Description("Product name.");
            Field(x => x.Description, nullable: true).Description("Product description.");
            Field(x => x.Price).Description("Product price.");

            Field<CategoryType>(
                "category",
                resolve: context => categoryRepository.GetByIdAsync(context.Source.CategoryId).Result
             );
        }
    }
}
