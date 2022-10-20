using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_market.Infrastruture.Persistence.Migrations
{
    public partial class addedprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "Comercial",
                type: "real",
                maxLength: 50,
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Comercial");
        }
    }
}
