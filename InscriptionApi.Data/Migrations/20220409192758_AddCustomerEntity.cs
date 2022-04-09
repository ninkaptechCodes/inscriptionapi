using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ni_Soft.InscriptionApi.Data.Migrations
{
    public partial class AddCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Firstname", "Lastname", "UpdatedOn" },
                values: new object[] { 1L, new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326), null, "Frank", "Lacroix", null });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Firstname", "Lastname", "UpdatedOn" },
                values: new object[] { 2L, new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326), null, "Marie", "Kapinga", null });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Firstname", "Lastname", "UpdatedOn" },
                values: new object[] { 3L, new DateTime(2022, 4, 9, 21, 27, 57, 367, DateTimeKind.Local).AddTicks(2326), null, "Lea", "Agnes", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
