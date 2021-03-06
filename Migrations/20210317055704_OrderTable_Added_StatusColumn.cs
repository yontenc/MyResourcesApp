﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MyResourcesApp.Migrations
{
    public partial class OrderTable_Added_StatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<char>(
                name: "Status",
                table: "orders",
                type: "character(1)",
                nullable: false,
                defaultValue: ' ');
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");
        }
    }
}
