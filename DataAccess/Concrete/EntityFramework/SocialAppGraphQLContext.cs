using Core.Entities.Concrete;
using Entities.Concrete.GraphQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SocialAppGraphQLContext:DbContext
    {
        public SocialAppGraphQLContext(DbContextOptions<SocialAppGraphQLContext> options) : base(options)
        {

        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ConstantRoom> ConstantRooms { get; set; }
        public DbSet<LikeKind> LikeKinds { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<ChatLevel> ChatLevels { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Prefer> Prefers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<ProfileQuestion> ProfileQuestions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ConstantRoomMember> ConstantRoomMembers { get; set; }
        public DbSet<RoomMember> RoomMembers { get; set; }
    }
}
