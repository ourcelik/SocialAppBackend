using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.Likes
{
    public class LikeType:ObjectType<Like>
    {
        protected override void Configure(IObjectTypeDescriptor<Like> descriptor)
        {

            descriptor
                .Field(l => l.Receiver)
                .ResolveWith<Resolvers>(r => r.GetReceiver(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>();
            descriptor
               .Field(l => l.Sender)
               .ResolveWith<Resolvers>(r => r.GetSender(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>();
            descriptor
               .Field(l => l.Kind)
               .ResolveWith<Resolvers>(r => r.GetLikeKind(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>();

        }
        public class Resolvers
        {
            public Profile GetReceiver(Like like,[ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.ProfileId == like.ReceiverId);
            }
            public Profile GetSender(Like like, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.ProfileId == like.SenderId);
            }
            public LikeKind GetLikeKind(Like like, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.LikeKinds.FirstOrDefault(l=> l.LikeKindId == like.KindId);
            }
        }
    }
}
