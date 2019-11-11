using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FromTheFuture.Infrastructure.Migrations
{
    public partial class Initialization : Migration
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
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureBoxes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FutureItems",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.PrimaryKey("PK_FutureBoxItems", x => new { x.FutureItemId, x.FutureBoxId });
                    table.ForeignKey(
                        name: "FK_FutureBoxItems_FutureBoxes_FutureBoxId",
                        column: x => x.FutureBoxId,
                        principalSchema: "user",
                        principalTable: "FutureBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    //manually added as owned entities with multiple owners is not yet supported by EF Core
                    table.ForeignKey(
                        name: "FK_FutureBoxItems_FutureItems_FutureItemId",
                        column: x => x.FutureItemId,
                        principalSchema: "user",
                        principalTable: "FutureItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FutureBoxes_UserId",
                schema: "user",
                table: "FutureBoxes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FutureBoxItems_FutureBoxId",
                schema: "user",
                table: "FutureBoxItems",
                column: "FutureBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_FutureItems_UserId",
                schema: "user",
                table: "FutureItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FutureBoxItems",
                schema: "user");

            migrationBuilder.DropTable(
                name: "FutureItems",
                schema: "user");

            migrationBuilder.DropTable(
                name: "FutureBoxes",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "user");
        }
    }
}
