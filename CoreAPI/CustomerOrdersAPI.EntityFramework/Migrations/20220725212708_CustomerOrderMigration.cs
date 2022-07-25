using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerOrdersAPI.EntityFramework.Migrations
{
    public partial class CustomerOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMaterial",
                columns: table => new
                {
                    MaterialId = table.Column<string>(type: "varchar(20)", nullable: false),
                    MaterialName = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaterialId", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerOrderId = table.Column<string>(type: "varchar(20)", nullable: false),
                    OriginAddress = table.Column<string>(type: "varchar(500)", nullable: false),
                    DestinationAddress = table.Column<string>(type: "varchar(500)", nullable: false),
                    MaterialQuantity = table.Column<int>(type: "int", nullable: false),
                    QuantityUnit = table.Column<string>(type: "varchar(20)", nullable: false),
                    TotalWeight = table.Column<int>(type: "int", nullable: false),
                    WeightUnit = table.Column<string>(type: "varchar(20)", nullable: false),
                    MaterialId = table.Column<string>(type: "varchar(20)", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderId", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderStatusDescription",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusDescription = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderStatusId", x => x.OrderStatusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMaterial");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblOrderStatusDescription");
        }
    }
}
