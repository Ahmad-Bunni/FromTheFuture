using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FromTheFuture.Infrastructure.Migrations
{
    public partial class ProjectInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FutureBoxes",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureBoxes_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FutureItems",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StorageUri = table.Column<string>(nullable: true),
                    ItemType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureItems_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FutureBoxItems",
                schema: "user",
                columns: table => new
                {
                    FutureBoxId = table.Column<Guid>(nullable: false),
                    FutureItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureBoxItems", x => new { x.FutureBoxId, x.FutureItemId });
                    table.ForeignKey(
                        name: "FK_FutureBoxItems_FutureBoxes_FutureBoxId",
                        column: x => x.FutureBoxId,
                        principalSchema: "user",
                        principalTable: "FutureBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FutureBoxItems_FutureItems_FutureItemId",
                        column: x => x.FutureItemId,
                        principalSchema: "user",
                        principalTable: "FutureItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FutureBoxes_UserID",
                schema: "user",
                table: "FutureBoxes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FutureBoxItems_FutureItemId",
                schema: "user",
                table: "FutureBoxItems",
                column: "FutureItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FutureItems_UserID",
                schema: "user",
                table: "FutureItems",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FutureBoxItems",
                schema: "user");

            migrationBuilder.DropTable(
                name: "FutureBoxes",
                schema: "user");

            migrationBuilder.DropTable(
                name: "FutureItems",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "user");
        }
    }
}
