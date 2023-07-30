using Microsoft.EntityFrameworkCore;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public static class ContextGenerator
    {
        public static YourSchedulerDbContext Generate()
        {
            var options = new DbContextOptionsBuilder<YourSchedulerDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new YourSchedulerDbContext(options);
        }
    }
}
