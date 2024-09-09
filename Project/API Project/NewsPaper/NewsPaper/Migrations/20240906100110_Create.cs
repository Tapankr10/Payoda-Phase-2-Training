using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsPaper.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CredibilityScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "Bio", "CredibilityScore", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe is a veteran journalist with over 20 years of experience in investigative reporting.", 9.5m, "John Doe" },
                    { 2, "Jane Smith is an award-winning author and editor, known for her insightful articles on technology and innovation.", 8.7m, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "AuthorID", "Content", "PublishedDate", "Title", "Views" },
                values: new object[,]
                {
                    { 1, 1, "A major event has shaken the tech world, with significant implications for the industry.", new DateTime(2024, 8, 27, 15, 31, 8, 584, DateTimeKind.Local).AddTicks(506), "Breaking News: Major Event in Tech", 1200 },
                    { 2, 2, "The latest advances in healthcare technology are transforming patient care.", new DateTime(2024, 9, 1, 15, 31, 8, 584, DateTimeKind.Local).AddTicks(528), "Healthcare Advances in 2024", 850 },
                    { 3, 2, "AI and robotics are set to revolutionize various industries. Here's what to expect in the coming years.", new DateTime(2024, 9, 4, 15, 31, 8, 584, DateTimeKind.Local).AddTicks(530), "The Future of AI and Robotics", 2300 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorID",
                table: "Articles",
                column: "AuthorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
