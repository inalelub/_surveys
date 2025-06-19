using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _surveys.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavouriteFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleMovie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleRadio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleEatOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleTV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
