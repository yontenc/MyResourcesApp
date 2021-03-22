using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyResourcesApp.Migrations
{
    public partial class OrderTable_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "depositAdvanceHistory",
                columns: table => new
                {
                    DepositeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepositTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    BalanceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerCID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depositAdvanceHistory", x => x.DepositeID);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    CID = table.Column<string>(type: "text", nullable: false),
                    productName = table.Column<string>(type: "text", nullable: false),
                    SiteID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TransportAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    AdvanceBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.CID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "depositAdvanceHistory");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
