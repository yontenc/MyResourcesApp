using Microsoft.EntityFrameworkCore.Migrations;

namespace MyResourcesApp.Migrations
{
    public partial class TableNameChangedFromUperCaseTOLowerCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advancehistory",
                table: "Advancehistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advance",
                table: "Advance");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "site");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "customer");

            migrationBuilder.RenameTable(
                name: "Advancehistory",
                newName: "advancehistory");

            migrationBuilder.RenameTable(
                name: "Advance",
                newName: "advance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_site",
                table: "site",
                column: "SiteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "productName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "CID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_advancehistory",
                table: "advancehistory",
                column: "DepositeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_advance",
                table: "advance",
                column: "CustomerCID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_site",
                table: "site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_advancehistory",
                table: "advancehistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_advance",
                table: "advance");

            migrationBuilder.RenameTable(
                name: "site",
                newName: "Site");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "advancehistory",
                newName: "Advancehistory");

            migrationBuilder.RenameTable(
                name: "advance",
                newName: "Advance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "SiteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "productName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advancehistory",
                table: "Advancehistory",
                column: "DepositeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advance",
                table: "Advance",
                column: "CustomerCID");
        }
    }
}
