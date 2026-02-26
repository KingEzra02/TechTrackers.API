using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TechTrackers.Data
{
    public class TechTrackersDbContextFactory : IDesignTimeDbContextFactory<TechTrackersDbContext>
    {
        public TechTrackersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TechTrackersDbContext>();

            // Option 1: Use environment variable (recommended for local)
            var conn = Environment.GetEnvironmentVariable("DefaultConnection");

            // Option 2 (fallback): hardcode temporarily (only for testing, remove later)
            // var conn = "Server=tcp:...;Initial Catalog=...;User ID=...;Password=...;Encrypt=True;...";

            if (string.IsNullOrWhiteSpace(conn))
                throw new InvalidOperationException("DefaultConnection environment variable not set.");

            optionsBuilder.UseSqlServer(conn);

            return new TechTrackersDbContext(optionsBuilder.Options);
        }
    }
}