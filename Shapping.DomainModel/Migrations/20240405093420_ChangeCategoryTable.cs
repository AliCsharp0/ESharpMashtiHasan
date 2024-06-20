using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shapping.DomainModel.Migrations
{
    public partial class ChangeCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 5, 13, 4, 20, 651, DateTimeKind.Local).AddTicks(8094),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 4, 14, 9, 55, 478, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.AlterColumn<string>(
                name: "LineAge",
                table: "Categories",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DirectChildCount",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectChildCount",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 4, 14, 9, 55, 478, DateTimeKind.Local).AddTicks(3320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 5, 13, 4, 20, 651, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.AlterColumn<string>(
                name: "LineAge",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);
        }
    }
}
