using FromTheFuture.Domain.Users.FutureItems;
using FromTheFuture.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.FutureItems
{
    public class FutureItemsEntityTypeConfiguration : IEntityTypeConfiguration<FutureItem>
    {
        public void Configure(EntityTypeBuilder<FutureItem> builder)
        {
            builder.ToTable("FutureItems", SchemaNames.FutureUser);
            builder.HasMany(TableNavigationPaths.FutureBoxItemTable).WithOne().HasForeignKey("FutureItemId");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
