using Microsoft.EntityFrameworkCore.Migrations;

namespace MyResourcesApp.Migrations
{
    public partial class TableNameChangedToLowerCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_siteInfo",
                table: "siteInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderInfo",
                table: "orderInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_depositAdvanceHistory",
                table: "depositAdvanceHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_advanceDeposit",
                table: "advanceDeposit");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "siteInfo",
                newName: "Site");

            migrationBuilder.RenameTable(
                name: "orderInfo",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "depositAdvanceHistory",
                newName: "Advancehistory");

            migrationBuilder.RenameTable(
                name: "advanceDeposit",
                newName: "Advance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "productName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "SiteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advancehistory",
                table: "Advancehistory",
                column: "DepositeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advance",
                table: "Advance",
                column: "CustomerCID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advancehistory",
                table: "Advancehistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advance",
                table: "Advance");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "customer");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "siteInfo");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orderInfo");

            migrationBuilder.RenameTable(
                name: "Advancehistory",
                newName: "depositAdvanceHistory");

            migrationBuilder.RenameTable(
                name: "Advance",
                newName: "advanceDeposit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "productName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "CID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_siteInfo",
                table: "siteInfo",
                column: "SiteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderInfo",
                table: "orderInfo",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_depositAdvanceHistory",
                table: "depositAdvanceHistory",
                column: "DepositeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_advanceDeposit",
                table: "advanceDeposit",
                column: "CustomerCID");
        }
    }
}
