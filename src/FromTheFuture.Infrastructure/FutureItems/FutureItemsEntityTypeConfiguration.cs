using FromTheFuture.Domain.Users.FutureItems;
using FromTheFuture.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.FutureItems;

public class FutureItemsEntityTypeConfiguration : IEntityTypeConfiguration<FutureItem>
{
    public void Configure(EntityTypeBuilder<FutureItem> builder)
    {
        builder.ToTable("FutureItems", SchemaNames.FutureUser);
        builder.HasMany(TableNavigationPaths.FutureBoxItemTable).WithOne().HasForeignKey("FutureItemId").OnDelete(DeleteBehavior.Restrict);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
    }
}
