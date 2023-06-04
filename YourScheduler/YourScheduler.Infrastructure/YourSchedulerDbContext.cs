using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using YourScheduler.Infrastructure.Entities;
using System.Buffers.Text;
using YourScheduler.Infrastructure;

namespace YourScheduler.Infrastructure
{
    public class YourSchedulerDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<ApplicationUserEvent> ApplicationUsersEvents { get; set; }
        public virtual DbSet<ApplicationUserTeam> ApplicationUsersTeams { get; set; }


        public YourSchedulerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<UserTeam>().HasKey(ut => new { ut.UserId, ut.TeamId });

            //builder.Entity<UserTeam>().HasOne<ApplicationUser>(us => us.ApplicationUser).WithMany(ut => ut.UsersTeams).HasForeignKey(us => us.UserId);

            //builder.Entity<UserTeam>().HasOne<Team>(t => t.Team).WithMany(ut => ut.UsersTeams).HasForeignKey(t => t.TeamId);

            //builder.Entity<UserEvent>().HasKey(ue => new { ue.UserId, ue.EventId });

            //builder.Entity<UserEvent>().HasOne<ApplicationUser>(us => us.ApplicationUser).WithMany(ut => ut.UsersEvents).HasForeignKey(us => us.UserId);

            //builder.Entity<UserEvent>().HasOne<Event>(e => e.Event).WithMany(ut => ut.UsersEvents).HasForeignKey(e => e.EventId);


            // seed data to database:
            builder.Entity<ApplicationUser>()
                .HasData(SeedData.GetUsersSeed());
            builder.Entity<Event>()
                .HasData(SeedData.GetEventsSeed());
            builder.Entity<Team>()
                .HasData(SeedData.GetTeamsSeed());
            builder.Entity<ApplicationUserEvent>()
                .HasData(SeedData.GetApplicationUserEventSeed());
            builder.Entity<ApplicationUserTeam>()
                .HasData(SeedData.GetApplicationUserTeamSeed());
        }
    }
}
