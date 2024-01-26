using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class initPeriods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Form_Period_PeriodId",
                table: "Form");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Period",
                table: "Period");

            migrationBuilder.RenameTable(
                name: "Period",
                newName: "Periods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Periods",
                table: "Periods",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "Id", "End", "Start" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 20, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 10, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 5, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Form_Periods_PeriodId",
                table: "Form",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Form_Periods_PeriodId",
                table: "Form");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Periods",
                table: "Periods");

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Periods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Periods",
                newName: "Period");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Period",
                table: "Period",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Form_Period_PeriodId",
                table: "Form",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id");
        }
    }
}
