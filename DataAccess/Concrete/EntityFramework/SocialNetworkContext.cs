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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D3TIOUO;Database=Social_NetworkDB;Trusted_Connection=True");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks{ get; set; }
        public DbSet<Constant_room> Constant_Rooms { get; set; }
        public DbSet<CR_Member> CR_Members { get; set; }
        public DbSet<Like_Kind> Like_Kinds{ get; set; }
        public DbSet<Liked> Likeds { get; set; }
        public DbSet<Chat_level> Chat_Levels { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Prefer> Prefers { get; set; }
        public DbSet<Profile> Profiles{ get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<R_Member> R_Members { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Profile_Answer> Profile_Answers { get; set; }




    }
}
