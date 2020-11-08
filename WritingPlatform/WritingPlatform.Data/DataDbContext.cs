using System.Data.Entity;
using WritingPlatform.Data.Entities;

namespace WritingPlatform.Data
{
    internal sealed class DataDbContext : DbContext
    {
        public DataDbContext(string connectionString) : base(connectionString)
        {
            var config = new DataDbConfig();

            DbConfiguration.SetConfiguration(config);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Work>().ToTable(nameof(Work));
            modelBuilder.Entity<Comment>().ToTable(nameof(Comment));
        }
    }
}
