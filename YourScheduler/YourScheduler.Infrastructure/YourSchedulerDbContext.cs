using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YourScheduler.Infrastructure.Entities;

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

        }


    }
}
