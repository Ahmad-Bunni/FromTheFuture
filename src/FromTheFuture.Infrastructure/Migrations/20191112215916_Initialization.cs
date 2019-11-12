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
                name: "FutureBox",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureBox_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FutureItem",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureItem_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FutureBoxItem",
                schema: "user",
                columns: table => new
                {
                    FutureBoxId = table.Column<Guid>(nullable: false),
                    FutureItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureBoxItem", x => new { x.FutureBoxId, x.FutureItemId });
                    table.ForeignKey(
                        name: "FK_FutureBoxItem_FutureBox_FutureBoxId",
                        column: x => x.FutureBoxId,
                        principalSchema: "user",
                        principalTable: "FutureBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FutureBoxItem_FutureItem_FutureItemId",
                        column: x => x.FutureItemId,
                        principalSchema: "user",
                        principalTable: "FutureItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FutureBox_UserID",
                schema: "user",
                table: "FutureBox",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FutureBoxItem_FutureItemId",
                schema: "user",
                table: "FutureBoxItem",
                column: "FutureItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FutureItem_UserID",
                schema: "user",
                table: "FutureItem",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FutureBoxItem",
                schema: "user");

            migrationBuilder.DropTable(
                name: "FutureBox",
                schema: "user");

            migrationBuilder.DropTable(
                name: "FutureItem",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "user");
        }
    }
}
