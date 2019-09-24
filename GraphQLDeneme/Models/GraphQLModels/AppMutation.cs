using GraphQL.Types;
using GraphQLDeneme.Data;

namespace GraphQLDeneme.Models.GraphQLModels
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IProductRepository productRepository)
        {
            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
                    ),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("product");
                    return productRepository.Add(product);
                }
                );
        }

        public class ProductInputType : InputObjectGraphType
        {
            public ProductInputType()
            {
                Name = "productInput";
                Field<NonNullGraphType<StringGraphType>>("name");
                Field<NonNullGraphType<FloatGraphType>>("price");
                Field<StringGraphType>("description");
                Field<NonNullGraphType<IntGraphType>>("categoryId");
            }
        }
    }
}
