using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPaper.Migrations
{
    /// <inheritdoc />
    public partial class News : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 8, 27, 15, 31, 8, 584, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 1, 15, 31, 8, 584, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 9, 4, 15, 31, 8, 584, DateTimeKind.Local).AddTicks(530));
        }
    }
}
