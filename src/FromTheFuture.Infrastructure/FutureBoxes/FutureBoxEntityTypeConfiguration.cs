using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.FutureBoxes
{
    public class FutureBoxEntityTypeConfiguration : IEntityTypeConfiguration<FutureBox>
    {
        public void Configure(EntityTypeBuilder<FutureBox> builder)
        {
            builder.ToTable("FutureBoxes", SchemaNames.FutureUser);
            builder.HasMany(TableNavigationPaths.FutureBoxItemTable).WithOne().HasForeignKey("FutureBoxId");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
