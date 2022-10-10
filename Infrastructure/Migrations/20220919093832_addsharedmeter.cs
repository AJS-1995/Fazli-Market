using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addsharedmeter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_MSOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meter_Id = table.Column<int>(type: "int", nullable: false),
                    Date_Rrad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Date_Pay = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Grade_Past = table.Column<int>(type: "int", nullable: false),
                    Grade_Now = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MSOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Shared_Meters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxMeter_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Use = table.Column<bool>(type: "bit", nullable: false),
                    Shop_Id = table.Column<int>(type: "int", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Shared_Meters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_MSOperations");

            migrationBuilder.DropTable(
                name: "Tbl_Shared_Meters");
        }
    }
}
