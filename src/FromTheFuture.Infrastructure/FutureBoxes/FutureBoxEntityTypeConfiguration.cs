using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.FutureBoxes;

public class FutureBoxEntityTypeConfiguration : IEntityTypeConfiguration<FutureBox>
{
    public void Configure(EntityTypeBuilder<FutureBox> builder)
    {
        builder.ToTable("FutureBoxes", SchemaNames.FutureUser);
        builder.HasMany(TableNavigationPaths.FutureBoxItemTable).WithOne().HasForeignKey("FutureBoxId").OnDelete(DeleteBehavior.Restrict);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
    }
}
