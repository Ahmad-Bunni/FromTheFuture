using FromTheFuture.Domain.Users;
using FromTheFuture.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey("Id");
            builder.Property("Id").ValueGeneratedNever();
            builder.HasMany(TableNames.FutureBoxes).WithOne().HasForeignKey("UserID");
            builder.HasMany(TableNames.FutureItems).WithOne().HasForeignKey("UserID");

        }
    }
}
