using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReposPattern.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelSet",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "111, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelSet", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "RoomSet",
                columns: table => new
                {
                    RoomNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSet", x => x.RoomNo);
                    table.ForeignKey(
                        name: "FK_RoomSet_HotelSet_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelSet",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotelSet",
                columns: new[] { "HotelId", "HotelName" },
                values: new object[,]
                {
                    { 111, "Taj Hotel" },
                    { 112, "Phenoix" }
                });

            migrationBuilder.InsertData(
                table: "RoomSet",
                columns: new[] { "RoomNo", "HotelId", "Price", "RoomType" },
                values: new object[,]
                {
                    { 1, 111, 35000m, "AC" },
                    { 2, 111, 4000m, " Normal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomSet_HotelId",
                table: "RoomSet",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomSet");

            migrationBuilder.DropTable(
                name: "HotelSet");
        }
    }
}
