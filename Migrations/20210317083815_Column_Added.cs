﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MyResourcesApp.Migrations
{
    public partial class Column_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "orders");

            migrationBuilder.AddColumn<char>(
                name: "OrderStatus",
                table: "orders",
                type: "character(1)",
                nullable: false,
                defaultValue: ' ');
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
