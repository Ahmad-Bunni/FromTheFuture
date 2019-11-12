using FromTheFuture.Domain.Users;
using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Domain.Users.FutureItems;
using FromTheFuture.Infrastructure.SeedWork;
using FromTheFuture.Infrastructure.Users;
using FromTheFuture.Infrastructure.Users.FutureBoxes;
using FromTheFuture.Infrastructure.Users.FutureItems;
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
            modelBuilder.HasDefaultSchema(SchemaNames.FutureUser);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FutureBoxEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FutureItemsEntityTypeConfiguration());

            //many to many configuration
            modelBuilder.Entity<FutureBoxItem>().HasKey(x => new { x.FutureBoxId, x.FutureItemId });
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
