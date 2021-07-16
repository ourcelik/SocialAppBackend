using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.Rooms
{
    public class RoomType : ObjectType<Room>
    {
        //[NotMapped]
        //public ChatLevel ChatLevel { get; set; }
        //[NotMapped]
        //public List<RoomMember> RoomMembers { get; set; }
        protected override void Configure(IObjectTypeDescriptor<Room> descriptor)
        {
            descriptor
               .Field(p => p.ChatLevel)
               .ResolveWith<Resolvers>(r => r.GetChatLevel(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>()
               .Description("");
            descriptor
               .Field(p => p.RoomMembers)
               .ResolveWith<Resolvers>(r => r.GetRoomMember(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>()
               .Description("");
            base.Configure(descriptor);
        }
       private class Resolvers
        {
            public ChatLevel GetChatLevel(Room roomType, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.ChatLevels.FirstOrDefault(c => c.ChatLevelId == roomType.ChatLevelId);
            }
            public IQueryable<RoomMember> GetRoomMember(Room roomType, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.RoomMembers.Where(r => r.RoomId == roomType.RoomId);
            }
        }
    }
}
