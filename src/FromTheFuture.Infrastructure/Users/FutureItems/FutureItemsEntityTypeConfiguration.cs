using FromTheFuture.Domain.Users.FutureItems;
using FromTheFuture.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.Users.FutureItems
{
    public class FutureItemsEntityTypeConfiguration : IEntityTypeConfiguration<FutureItem>
    {
        public void Configure(EntityTypeBuilder<FutureItem> builder)
        {
            builder.HasMany(TableNames.FutureBoxItems).WithOne().HasForeignKey("FutureItemId");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
