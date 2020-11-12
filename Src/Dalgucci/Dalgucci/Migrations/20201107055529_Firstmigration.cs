using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalgucci.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Manager_No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manager_ID = table.Column<string>(nullable: false),
                    Manager_Pwd = table.Column<string>(nullable: false),
                    Manager_name = table.Column<string>(nullable: false),
                    Manager_Tel = table.Column<string>(nullable: false),
                    Manager_RRN = table.Column<string>(nullable: false),
                    Manager_Address = table.Column<string>(nullable: false),
                    Manager_Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Manager_No);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    User_No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<string>(nullable: false),
                    Pwd = table.Column<string>(nullable: false),
                    User_name = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: false),
                    RRN = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.User_No);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Code = table.Column<string>(nullable: false),
                    Product_Name = table.Column<string>(nullable: false),
                    Place = table.Column<string>(nullable: false),
                    Quantity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_No);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Code = table.Column<string>(nullable: false),
                    User_No = table.Column<int>(nullable: false),
                    Order_Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_No);
                    table.ForeignKey(
                        name: "FK_Orders_Members_User_No",
                        column: x => x.User_No,
                        principalTable: "Members",
                        principalColumn: "User_No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_User_No",
                table: "Orders",
                column: "User_No");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
