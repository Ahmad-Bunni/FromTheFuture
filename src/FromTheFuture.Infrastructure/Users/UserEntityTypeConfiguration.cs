using FromTheFuture.Domain.Users;
using FromTheFuture.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", SchemaNames.FutureUser);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasMany(TableNavigationPaths.FutureBoxTable).WithOne().HasForeignKey("UserID").IsRequired();
            builder.HasMany(TableNavigationPaths.FutureItemTable).WithOne().HasForeignKey("UserID").IsRequired();

        }
    }
}
