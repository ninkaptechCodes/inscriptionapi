using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ni_Soft.InscriptionApi.Data.Migrations
{
    public partial class AddEmailToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "Email" },
                values: new object[] { new DateTime(2022, 4, 10, 0, 51, 32, 424, DateTimeKind.Local).AddTicks(4684), "f.lacroix@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "Email" },
                values: new object[] { new DateTime(2022, 4, 10, 0, 51, 32, 424, DateTimeKind.Local).AddTicks(4684), "m.kapinga@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "Email" },
                values: new object[] { new DateTime(2022, 4, 10, 0, 51, 32, 424, DateTimeKind.Local).AddTicks(4684), "a.lea@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326));
        }
    }
}
