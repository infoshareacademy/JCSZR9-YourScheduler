using Microsoft.EntityFrameworkCore;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public static class ContextGenerator
    {
        public static YourSchedulerDbContext Generate()
        {
            var optionBuilder = new DbContextOptionsBuilder<YourSchedulerDbContext>().UseInMemoryDatabase("HelperBase");
            var yourSchedulerDbContext = new YourSchedulerDbContext(optionBuilder.Options);
            yourSchedulerDbContext.Database.EnsureCreated();
            yourSchedulerDbContext.Database.EnsureDeleted();
            return yourSchedulerDbContext;    
        }
    }
}
