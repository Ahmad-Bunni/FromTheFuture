using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.FutureBoxes.FutureBoxItems
{
    public class FutureBoxItemsEntityTypeConfiguration : IEntityTypeConfiguration<FutureBoxItem>
    {
        public void Configure(EntityTypeBuilder<FutureBoxItem> builder)
        {
            builder.ToTable("FutureBoxItems", SchemaNames.FutureUser);
            builder.HasKey(x => new { x.FutureBoxId, x.FutureItemId });
        }
    }
}
