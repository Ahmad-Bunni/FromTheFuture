﻿// <auto-generated />
using System;
using FromTheFuture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FromTheFuture.Infrastructure.Migrations
{
    [DbContext(typeof(FutureDbContext))]
    partial class FutureDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("user")
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FromTheFuture.Domain.Users.FutureBoxes.FutureBox", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("FutureBox");
                });

            modelBuilder.Entity("FromTheFuture.Domain.Users.FutureBoxes.FutureBoxItem", b =>
                {
                    b.Property<Guid>("FutureBoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FutureItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FutureBoxId", "FutureItemId");

                    b.HasIndex("FutureItemId");

                    b.ToTable("FutureBoxItem");
                });

            modelBuilder.Entity("FromTheFuture.Domain.Users.FutureItems.FutureItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("FutureItem");
                });

            modelBuilder.Entity("FromTheFuture.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FromTheFuture.Domain.Users.FutureBoxes.FutureBox", b =>
                {
                    b.HasOne("FromTheFuture.Domain.Users.User", null)
                        .WithMany("_futureBoxes")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("FromTheFuture.Domain.Users.FutureBoxes.FutureBoxItem", b =>
                {
                    b.HasOne("FromTheFuture.Domain.Users.FutureBoxes.FutureBox", null)
                        .WithMany("_futureBoxItems")
                        .HasForeignKey("FutureBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FromTheFuture.Domain.Users.FutureItems.FutureItem", null)
                        .WithMany("_futureBoxItems")
                        .HasForeignKey("FutureItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FromTheFuture.Domain.Users.FutureItems.FutureItem", b =>
                {
                    b.HasOne("FromTheFuture.Domain.Users.User", null)
                        .WithMany("_futureItems")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
