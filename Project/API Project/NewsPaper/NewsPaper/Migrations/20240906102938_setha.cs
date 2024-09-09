using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPaper.Migrations
{
    /// <inheritdoc />
    public partial class setha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 8, 27, 15, 59, 35, 883, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 1, 15, 59, 35, 883, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 4, 15, 59, 35, 883, DateTimeKind.Local).AddTicks(5293));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "users");

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
    }
}
