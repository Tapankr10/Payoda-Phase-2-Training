using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPaper.Migrations
{
    /// <inheritdoc />
    public partial class sam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 8, 27, 15, 36, 56, 203, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 1, 15, 36, 56, 203, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 4, 15, 36, 56, 203, DateTimeKind.Local).AddTicks(2770));
        }
    }
}
