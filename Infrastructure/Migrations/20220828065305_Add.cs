using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_BoxMeters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BoxMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    Access = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    N_Invoice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ph_Invoice = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Id_Money = table.Column<int>(type: "int", nullable: false),
                    PayBox_Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Expense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ExSlaRecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    PayBox_Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ExSlaRecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GeneralMeters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cod = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GeneralMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_In_Out_Inventorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Ph_Invoice = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MoneyId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_In_Out_Inventorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Inventorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Inventorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Meters",
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
                    table.PrimaryKey("PK_Tbl_Meters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Moneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Moneys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MOperations",
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
                    Complete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Other = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MPays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meter_Id = table.Column<int>(type: "int", nullable: false),
                    MOperation_Id = table.Column<int>(type: "int", nullable: false),
                    PayBox_Id = table.Column<int>(type: "int", nullable: false),
                    Date_Pay = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MPays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralMeter_Id = table.Column<int>(type: "int", nullable: false),
                    Date_Rrad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Date_Pay = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Grade_Past = table.Column<int>(type: "int", nullable: false),
                    Grade_Now = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PayBoxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PayBoxs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Pays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralMeter_Id = table.Column<int>(type: "int", nullable: false),
                    Operation_Id = table.Column<int>(type: "int", nullable: false),
                    PayBox_Id = table.Column<int>(type: "int", nullable: false),
                    Date_Pay = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ReceiptRents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ForRent_Id = table.Column<int>(type: "int", nullable: false),
                    Shop_Id = table.Column<int>(type: "int", nullable: false),
                    PayBox_Id = table.Column<int>(type: "int", nullable: false),
                    Shop_Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ReceiptRents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_4 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_5 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_6 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_7 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_8 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_9 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_10 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_11 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month_12 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shop_Id = table.Column<int>(type: "int", nullable: false),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    ForRent_Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Rents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Salarys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Month_Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Salarys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ShopForRent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Id_Card = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Id_Card_Scan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Line_Contract_Scan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Start_Date = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    End_Date = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    Shop_Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ShopForRent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rent = table.Column<bool>(type: "bit", nullable: false),
                    ForRent = table.Column<int>(type: "int", nullable: false),
                    ForSold = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    End_Date = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Meter = table.Column<bool>(type: "bit", nullable: false),
                    Rest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Sla_Recs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    N_Invoice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    Person_Id = table.Column<int>(type: "int", nullable: false),
                    PayBox_Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Sla_Recs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Accounts_Tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Accounts_RoleId",
                table: "Tbl_Accounts",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Accounts");

            migrationBuilder.DropTable(
                name: "Tbl_BoxMeters");

            migrationBuilder.DropTable(
                name: "Tbl_Employees");

            migrationBuilder.DropTable(
                name: "Tbl_Expense");

            migrationBuilder.DropTable(
                name: "Tbl_ExSlaRecs");

            migrationBuilder.DropTable(
                name: "Tbl_GeneralMeters");

            migrationBuilder.DropTable(
                name: "Tbl_In_Out_Inventorys");

            migrationBuilder.DropTable(
                name: "Tbl_Inventorys");

            migrationBuilder.DropTable(
                name: "Tbl_Locations");

            migrationBuilder.DropTable(
                name: "Tbl_Meters");

            migrationBuilder.DropTable(
                name: "Tbl_Moneys");

            migrationBuilder.DropTable(
                name: "Tbl_MOperations");

            migrationBuilder.DropTable(
                name: "Tbl_MPays");

            migrationBuilder.DropTable(
                name: "Tbl_Operations");

            migrationBuilder.DropTable(
                name: "Tbl_PayBoxs");

            migrationBuilder.DropTable(
                name: "Tbl_Pays");

            migrationBuilder.DropTable(
                name: "Tbl_Persons");

            migrationBuilder.DropTable(
                name: "Tbl_ReceiptRents");

            migrationBuilder.DropTable(
                name: "Tbl_Rents");

            migrationBuilder.DropTable(
                name: "Tbl_Salarys");

            migrationBuilder.DropTable(
                name: "Tbl_ShopForRent");

            migrationBuilder.DropTable(
                name: "Tbl_Shops");

            migrationBuilder.DropTable(
                name: "Tbl_Sla_Recs");

            migrationBuilder.DropTable(
                name: "Tbl_Roles");
        }
    }
}
