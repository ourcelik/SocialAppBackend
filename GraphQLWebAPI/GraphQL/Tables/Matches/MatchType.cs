using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.Matches
{
    public class MatchType : ObjectType<Match>
    {
        protected override void Configure(IObjectTypeDescriptor<Match> descriptor)
        {
            descriptor
                .Field(m => m.ChatLevel)
                .ResolveWith<Resolvers>(r => r.GetChatLevel(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>();
            descriptor
                .Field(m => m.MatchProfile)
                .ResolveWith<Resolvers>(r => r.GetMatchProfile(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>();
            descriptor
                .Field(m => m.MatchedProfile)
                .ResolveWith<Resolvers>(r => r.GetMatchedProfile(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>();
        }
       
        private class Resolvers
        {
            public Profile GetMatchProfile(Match match, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.ProfileId == match.MatchProfileId);
            }
            public Profile GetMatchedProfile(Match match, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.ProfileId == match.MatchedProfileId);
            }
            public ChatLevel GetChatLevel(Match match, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.ChatLevels.FirstOrDefault(c=>c.ChatLevelId  == match.ChatLevelId);
            }
        }
    }
}
