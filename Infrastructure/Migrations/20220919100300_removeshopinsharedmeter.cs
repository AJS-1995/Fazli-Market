using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class removeshopinsharedmeter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shop_Id",
                table: "Tbl_Shared_Meters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Shop_Id",
                table: "Tbl_Shared_Meters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
