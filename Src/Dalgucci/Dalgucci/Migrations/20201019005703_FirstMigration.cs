using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalgucci.Migrations
{
    public partial class FirstMigration : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
