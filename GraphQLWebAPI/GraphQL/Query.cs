using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL
{
    [GraphQLDescription("Sorgulanabilir verileri temsil eder")]
    public class Query
    {
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Kullanıcılara sorulan soruları getirir")]
        public async Task<List<Question>> GetQuestion([ScopedService] SocialAppGraphQLContext context) => await context.Questions.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Kullanıcıya sorulan soruların cevaplarını getirir")]
        public async Task<List<Choice>> GetChoice([ScopedService] SocialAppGraphQLContext context) => await context.Choices.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Bank>> GetBank([ScopedService] SocialAppGraphQLContext context) => await context.Banks.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<ChatLevel>> GetChatLevel([ScopedService] SocialAppGraphQLContext context) => await context.ChatLevels.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<ConstantRoom>> GetConstantRoom([ScopedService] SocialAppGraphQLContext context) => await context.ConstantRooms.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<ConstantRoomMember>> GetConstantRoomMember([ScopedService] SocialAppGraphQLContext context) => await context.ConstantRoomMembers.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Gender>> GetGender([ScopedService] SocialAppGraphQLContext context) => await context.Genders.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<LikeKind>> GetLikeKind([ScopedService] SocialAppGraphQLContext context) => await context.LikeKinds.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Like>> GetLikes([ScopedService] SocialAppGraphQLContext context) => await context.Likes.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Match>> GetMatch([ScopedService] SocialAppGraphQLContext context) => await context.Matches.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Notification>> GetNotification([ScopedService] SocialAppGraphQLContext context) => await context.Notifications.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Photo>> GetPhoto([ScopedService] SocialAppGraphQLContext context) => await context.Photos.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Prefer>> GetPrefer([ScopedService] SocialAppGraphQLContext context) => await context.Prefers.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Profile>> GetProfile([ScopedService] SocialAppGraphQLContext context) => await context.Profiles.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<ProfileQuestion>> GetProfileQuestion([ScopedService] SocialAppGraphQLContext context) => await context.ProfileQuestions.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Rank>> GetRank([ScopedService] SocialAppGraphQLContext context) => await context.Ranks.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Room>> GetRoom([ScopedService] SocialAppGraphQLContext context) => await context.Rooms.ToListAsync();
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public async Task<List<RoomMember>> GetRoomMember([ScopedService] SocialAppGraphQLContext context) => await context.RoomMembers.ToListAsync();

    }
}
