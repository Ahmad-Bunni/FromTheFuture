using FromTheFuture.Domain.Users;
using FromTheFuture.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FromTheFuture.Infrastructure
{
    public class FutureDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public FutureDbContext(DbContextOptions<FutureDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

        }
        public class MyContextContextFactory : IDesignTimeDbContextFactory<FutureDbContext>
        {
            public FutureDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

                var builder = new DbContextOptionsBuilder<FutureDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new FutureDbContext(builder.Options);
            }
        }


    }
}
