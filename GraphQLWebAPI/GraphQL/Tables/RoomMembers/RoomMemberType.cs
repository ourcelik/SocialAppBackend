using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.RoomMembers
{
    public class RoomMemberType : ObjectType<RoomMember>
    {
        protected override void Configure(IObjectTypeDescriptor<RoomMember> descriptor)
        {
            descriptor
               .Field(r => r.Room)
               .ResolveWith<Resolvers>(r => r.GetRoom(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>()
               .Description("");
            descriptor
               .Field(r => r.Rank)
               .ResolveWith<Resolvers>(r => r.GetRank(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>()
               .Description("");

        }
        private class Resolvers
        {
           
            public Room GetRoom(RoomMember roomMember, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Rooms.FirstOrDefault(r => r.RoomId == roomMember.RoomId);
            }
            public Rank GetRank(RoomMember roomMember, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Ranks.FirstOrDefault(r => r.RankId == roomMember.RankId);
            }

        }
    }
}
