using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addyearsinrent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Months",
                table: "Tbl_ReceiptRents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Years",
                table: "Tbl_ReceiptRents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Months",
                table: "Tbl_ReceiptRents");

            migrationBuilder.DropColumn(
                name: "Years",
                table: "Tbl_ReceiptRents");
        }
    }
}
