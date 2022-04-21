using FromTheFuture.Domain.Users;
using FromTheFuture.Infrastructure.FutureBoxes;
using FromTheFuture.Infrastructure.FutureBoxes.FutureBoxItems;
using FromTheFuture.Infrastructure.FutureItems;
using FromTheFuture.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace FromTheFuture.Infrastructure;

public class FutureDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public FutureDbContext(DbContextOptions<FutureDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FutureBoxEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FutureItemsEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FutureBoxItemsEntityTypeConfiguration());
    }
}
