using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDeneme.Models.GraphQLModels
{
    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(IDependencyResolver resolver)
        : base(resolver)
        {
            Query = resolver.Resolve<EasyStoreQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
