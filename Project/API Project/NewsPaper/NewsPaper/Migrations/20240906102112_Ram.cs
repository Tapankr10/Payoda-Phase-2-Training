using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPaper.Migrations
{
    /// <inheritdoc />
    public partial class Ram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 8, 27, 15, 51, 10, 426, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 1, 15, 51, 10, 426, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 4, 15, 51, 10, 426, DateTimeKind.Local).AddTicks(1231));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 8, 27, 15, 41, 3, 817, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 1, 15, 41, 3, 817, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 4, 15, 41, 3, 817, DateTimeKind.Local).AddTicks(1833));
        }
    }
}
