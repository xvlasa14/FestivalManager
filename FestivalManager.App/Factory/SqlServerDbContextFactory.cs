using FestivalManager.DAL;
using Microsoft.EntityFrameworkCore;

namespace FestivalManager.App.Factory
{
    public class SqlServerDbContextFactory : IDbContextFactory<FestivalManagerDbContext>
    {
        private readonly string _connectionString;

        public SqlServerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public FestivalManagerDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FestivalManagerDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return new FestivalManagerDbContext(optionsBuilder.Options);
        }
    }
}
