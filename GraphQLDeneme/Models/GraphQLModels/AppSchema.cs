using GraphQL;
using GraphQL.Types;

namespace GraphQLDeneme.Models.GraphQLModels
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
        : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
