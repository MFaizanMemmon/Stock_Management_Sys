using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThemeApplyPractice.Migrations
{
    public partial class addField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurData",
                table: "purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "issuances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "issuances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "issuances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "PurData",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "issuances");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "issuances");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "issuances");
        }
    }
}
