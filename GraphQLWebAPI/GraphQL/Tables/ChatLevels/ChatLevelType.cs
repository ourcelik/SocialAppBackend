using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.ChatLevels
{
    public class ChatLevelType : ObjectType<ChatLevel>
    {
        protected override void Configure(IObjectTypeDescriptor<ChatLevel> descriptor)
        {

            descriptor
                .Field(c => c.ConstantRooms)
                .ResolveWith<Resolvers>(r => r.GetChoices(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>();
        }
        private class Resolvers
        {
            public IQueryable<ConstantRoom> GetChoices(ChatLevel chatLevel, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.ConstantRooms.Where(c => c.ChatLevelId == chatLevel.ChatLevelId);
            }
        }
    }
}
