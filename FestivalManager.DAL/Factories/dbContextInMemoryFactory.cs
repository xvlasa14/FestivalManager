using Microsoft.EntityFrameworkCore;

namespace FestivalManager.DAL.Factories
{
    public class DbContextInMemoryFactory : IDbContextFactory<FestivalManagerDbContext>
    {
        private readonly string _dbName;

        public DbContextInMemoryFactory(string dbName)
        {
            _dbName = dbName;
        }

        public FestivalManagerDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<FestivalManagerDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseInMemoryDatabase(_dbName);

            return new FestivalManagerDbContext(contextOptionsBuilder.Options);
        }
    }
}
