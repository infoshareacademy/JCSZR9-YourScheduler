using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public static class ContextGenerator
    {
        public static YourSchedulerDbContext Generate()
        {
            var optionBuilder = new DbContextOptionsBuilder<YourSchedulerDbContext>().UseInMemoryDatabase("HelperBase");

            return new YourSchedulerDbContext(optionBuilder.Options);
        }
    }
}
