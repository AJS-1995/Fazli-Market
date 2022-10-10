using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addId_Shopkeeper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForRent",
                table: "Tbl_Shops");

            migrationBuilder.RenameColumn(
                name: "ForSold",
                table: "Tbl_Shops",
                newName: "Id_Shopkeeper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Shopkeeper",
                table: "Tbl_Shops",
                newName: "ForSold");

            migrationBuilder.AddColumn<int>(
                name: "ForRent",
                table: "Tbl_Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
