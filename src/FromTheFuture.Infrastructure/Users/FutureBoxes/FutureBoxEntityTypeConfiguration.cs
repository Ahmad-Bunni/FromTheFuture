using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FromTheFuture.Infrastructure.Users.FutureBoxes
{
    public class FutureBoxEntityTypeConfiguration : IEntityTypeConfiguration<FutureBox>
    {
        public void Configure(EntityTypeBuilder<FutureBox> builder)
        {
            builder.HasMany(TableNames.FutureBoxItems).WithOne().HasForeignKey("FutureBoxId");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
