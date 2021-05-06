using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.ConstantRooms
{
    public class ConstantRoomType : ObjectType<ConstantRoom>
    {
        protected override void Configure(IObjectTypeDescriptor<ConstantRoom> descriptor)
        {

            descriptor
                .Field(c => c.ChatLevel)
                .ResolveWith<Resolvers>(r => r.GetQuestion(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("Oda Seviyesi");
            descriptor
              .Field(c => c.ConstantRoomMembers)
              .ResolveWith<Resolvers>(r => r.GetMembers(default!, default!))
              .UseDbContext<SocialAppGraphQLContext>();


        }
        private class Resolvers
        {
            public ChatLevel GetQuestion(ConstantRoom constantRoom, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.ChatLevels.FirstOrDefault(c => c.ChatLevelId == constantRoom.ChatLevelId);
            }
            public ConstantRoomMember GetMembers(ConstantRoom constantRoom, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.ConstantRoomMembers.FirstOrDefault(c => c.ConstantRoomId == constantRoom.RoomId);
            }
        }
    }
}
