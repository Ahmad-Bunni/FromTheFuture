using FromTheFuture.Domain.Users;
using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Domain.Users.FutureItems;
using FromTheFuture.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FromTheFuture.Infrastructure.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        internal const string FutureBoxes = "_futureBoxes";
        internal const string FutureItems = "_futureItems";
        internal const string FutureBoxItems = "_futureBoxItems";

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users", SchemaNames.FutureUser);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedNever();
            builder.OwnsMany<FutureBox>(FutureBoxes, x =>
            {
                x.ToTable(nameof(FutureBoxes), SchemaNames.FutureUser);
                x.WithOwner().HasForeignKey("UserId");
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).ValueGeneratedNever();

                x.OwnsMany<FutureBoxItem>(FutureBoxItems, y =>
                {
                    y.ToTable(nameof(FutureBoxItems), SchemaNames.FutureUser);
                    y.Property<Guid>("FutureBoxId");
                    y.Property<Guid>("FutureItemId");
                    y.WithOwner().HasForeignKey("FutureBoxId");
                    y.HasKey("FutureItemId", "FutureBoxId");
                });
            });

            builder.OwnsMany<FutureItem>(FutureItems, x =>
            {
                x.ToTable(nameof(FutureItems), SchemaNames.FutureUser);
                x.WithOwner().HasForeignKey("UserId");
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).ValueGeneratedNever();
            });
        }
    }
}
