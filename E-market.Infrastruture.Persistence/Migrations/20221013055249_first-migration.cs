using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_market.Infrastruture.Persistence.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoriesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    categoriesDescrition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsersPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UsersPasswork = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comercial",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comercialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    comercialDesciption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    comercialImage1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comercialImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comercialImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comercialImage4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comercialDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comercialCategoriesID = table.Column<int>(type: "int", nullable: false),
                    comercialUsersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comercial", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comercial_Categories_comercialCategoriesID",
                        column: x => x.comercialCategoriesID,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comercial_Users_comercialUsersID",
                        column: x => x.comercialUsersID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comercial_comercialCategoriesID",
                table: "Comercial",
                column: "comercialCategoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Comercial_comercialUsersID",
                table: "Comercial",
                column: "comercialUsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comercial");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
