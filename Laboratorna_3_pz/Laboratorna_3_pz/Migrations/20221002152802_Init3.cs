using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorna_3_pz.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Final_Product_Price",
                table: "Products_in_Basket",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Final_Product_Price",
                table: "Products_in_Basket");
        }
    }
}
