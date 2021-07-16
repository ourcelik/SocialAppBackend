using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.ConstantRoomMembers
{
    public class ConstantRoomMemberType : ObjectType<ConstantRoomMember>
    {
        protected override void Configure(IObjectTypeDescriptor<ConstantRoomMember> descriptor)
        {
            descriptor
                .Field(c => c.ConstantRoom)
                .ResolveWith<Resolvers>(r => r.GetConstantRoom(default!, default!));
            descriptor
                .Field(c => c.Rank)
                .ResolveWith<Resolvers>(r => r.GetRank(default!, default!));
        }

        private class Resolvers
        {
            public ConstantRoom GetConstantRoom(ConstantRoomMember member,[ScopedService] SocialAppGraphQLContext context)
            {
                return context.ConstantRooms.FirstOrDefault(c => c.ChatLevelId == member.ConstantRoomId);
            }
            public Rank GetRank(ConstantRoomMember member, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Ranks.FirstOrDefault(r => r.RankId == member.RankId);
            }
        }
    }
}

