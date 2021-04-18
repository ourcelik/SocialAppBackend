using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SocialNetworkContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D3TIOUO;Database=Socialnetworkdb;Trusted_Connection=True");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks{ get; set; }
        public DbSet<ConstantRoom> ConstantRooms { get; set; }
        public DbSet<ConstantRoomMember> ConstantRoomMembers { get; set; }
        public DbSet<LikeKind> LikeKinds { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<ChatLevel> ChatLevels { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Prefer> Prefers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<RoomMember> RoomMembers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rank> ProfileAnswers { get; set; }
        public DbSet<ProfileQuestion> ProfileQuestions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Gender> Genders { get; set; }





    }
}
