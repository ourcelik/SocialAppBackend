using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.Prefers
{
    public class PreferType :ObjectType<Prefer>
    {
        protected override void Configure(IObjectTypeDescriptor<Prefer> descriptor)
        {
            descriptor
                .Field(p => p.Profile)
                .ResolveWith<Resolvers>(r => r.GetProfile(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("Fotonun ail olduğu profile");
        }
        private class Resolvers
        {
            public Profile GetProfile(Prefer prefer,[ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.PreferId == p.PreferId);
            }
        }
    }
}
