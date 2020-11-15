using GraphQL;
using GraphQL_API.Entities;
using GraphQL.Types;   



namespace GraphQL_API.GraphQL
{
    public class GraphQLSchema:Schema, ISchema
        {
            public GraphQLSchema(IDependencyResolver resolver):base(resolver)
            {
                Query = resolver.Resolve<FactInterventionQuery>();

            }
        }
}