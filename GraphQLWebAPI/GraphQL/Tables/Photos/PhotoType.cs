using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.Photos
{
    public class PhotoType :ObjectType<Photo>
    {
        protected override void Configure(IObjectTypeDescriptor<Photo> descriptor)
        {
            descriptor
                .Field(p => p.Profile)
                .ResolveWith<Resolvers>(r => r.GetProfile(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("Fotonun ail olduğu profile");
        }
        private class Resolvers
        {
            public Profile GetProfile(Photo photo,[ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.ProfileId == photo.ProfileId);
            }
        }
    }
}
