using GraphQL.Types;
using GraphQLDeneme.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace GraphQLDeneme.Models.GraphQLModels
{
    public class EasyStoreQuery : ObjectGraphType
    {
        private IHttpContextAccessor _httpContextAccessor;

        public EasyStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Category id" }
                ),
                resolve: context => categoryRepository.GetByIdAsync(context.GetArgument<int>("id")).Result
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Product id" },
                    new QueryArgument<StringGraphType> { Name = "name", Description = "Product name" }
                ),
                resolve: context =>
                {
                    if (string.IsNullOrEmpty(context.GetArgument<string>("name")))
                    {
                        return productRepository.GetByIdAsync(context.GetArgument<int>("id")).Result;
                    }

                    return productRepository.GetByIdAsync(context.GetArgument<int>("id")).Result;
                });

            Field<ListGraphType<ProductType>>(
                "products",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "first", Description = "First n items" }
                    ),
                resolve: context =>
                {
                    var firstTake = context.GetArgument<int>("first");
                    if (firstTake > 0)
                    {
                        return productRepository.GetAllAsync().Result.Take(firstTake);
                    }

                    return productRepository.GetAllAsync();
                });
        }
    }
}
