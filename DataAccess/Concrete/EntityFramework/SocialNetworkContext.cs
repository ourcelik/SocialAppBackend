using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SocialNetworkContext:DbContext
    {
        
        public SocialNetworkContext():base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D3TIOUO;Database=Socialnetworkdb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Entities.Concrete.User> Users { get; set; }
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
        public DbSet<Post>  Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<PostInfo> PostInfos { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<CommentNotification> CommentNotifications { get; set; }









    }
}
