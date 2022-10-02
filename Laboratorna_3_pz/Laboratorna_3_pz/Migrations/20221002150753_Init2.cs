﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorna_3_pz.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products_in_Basket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Product_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Product_Provider = table.Column<string>(type: "TEXT", nullable: false),
                    Product_Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Product_Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_in_Basket", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_in_Basket");
        }
    }
}
