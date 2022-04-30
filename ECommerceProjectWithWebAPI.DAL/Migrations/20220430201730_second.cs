using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceProjectWithWebAPI.DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 30, 23, 17, 30, 611, DateTimeKind.Local).AddTicks(9729));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 4, 30, 19, 47, 12, 167, DateTimeKind.Local).AddTicks(6247));
        }
    }
}
