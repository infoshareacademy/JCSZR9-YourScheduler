using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public class YourSchedulerContextInMemory:DbContext
    {
        private DbContextOptionsBuilder<YourSchedulerContextInMemory> optionsBuilder => optionsBuilder.UseInMemoryDatabase("YourSchedulerInMemory");

        public YourSchedulerContextInMemory(DbContextOptions<YourSchedulerContextInMemory> options):base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }
    }
}
