using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Data;
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
        public IQueryable<Question> GetQuestion([ScopedService]SocialAppGraphQLContext context)
        {
            return context.Questions;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Kullanıcıya sorulan soruların cevaplarını getirir")]
        public IQueryable<Choice> GetChoice([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Choices;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Bank> GetBank([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Banks;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ChatLevel> GetChatLevel([ScopedService] SocialAppGraphQLContext context)
        {
            return context.ChatLevels;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ConstantRoom> GetConstantRoom([ScopedService] SocialAppGraphQLContext context)
        {
            return context.ConstantRooms;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ConstantRoomMember> GetConstantRoomMember([ScopedService] SocialAppGraphQLContext context)
        {
            return context.ConstantRoomMembers;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Gender> GetGender([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Genders;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<LikeKind> GetLikeKind([ScopedService] SocialAppGraphQLContext context)
        {
            return context.LikeKinds;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Like> GetLikes([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Likes;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Match> GetMatch([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Matches;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Notification> GetNotification([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Notifications;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Photo> GetPhoto([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Photos;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Prefer> GetPrefer([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Prefers;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Profile> GetProfile([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Profiles;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ProfileQuestion> GetProfileQuestion([ScopedService] SocialAppGraphQLContext context)
        {
            return context.ProfileQuestions;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Rank> GetRank([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Ranks;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Room> GetRoom([ScopedService] SocialAppGraphQLContext context)
        {
            return context.Rooms;
        }
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RoomMember> GetRoomMember([ScopedService] SocialAppGraphQLContext context)
        {
            return context.RoomMembers;
        }
       
    }
}
