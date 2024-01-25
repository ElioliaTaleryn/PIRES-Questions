using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class initTimerCD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_TimerCD_TimerCDId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_TimerCD_TimerCDId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimerCD",
                table: "TimerCD");

            migrationBuilder.RenameTable(
                name: "TimerCD",
                newName: "Timers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timers",
                table: "Timers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "29a0540d-a30f-48f9-a825-46ffb6ee821f", "0b5d9b35-532d-4d0c-aeab-0372ea4ac6b7" });

            migrationBuilder.InsertData(
                table: "Timers",
                columns: new[] { "Id", "CountDown" },
                values: new object[] { 1, 90 });

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Timers_TimerCDId",
                table: "Forms",
                column: "TimerCDId",
                principalTable: "Timers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Timers_TimerCDId",
                table: "Questions",
                column: "TimerCDId",
                principalTable: "Timers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Timers_TimerCDId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Timers_TimerCDId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timers",
                table: "Timers");

            migrationBuilder.DeleteData(
                table: "Timers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Timers",
                newName: "TimerCD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimerCD",
                table: "TimerCD",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "381c3c83-d566-4c6b-a3f0-ff854ac19c7a", "a4286c9e-5dcd-4213-9401-0538b96c84e9" });

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_TimerCD_TimerCDId",
                table: "Forms",
                column: "TimerCDId",
                principalTable: "TimerCD",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_TimerCD_TimerCDId",
                table: "Questions",
                column: "TimerCDId",
                principalTable: "TimerCD",
                principalColumn: "Id");
        }
    }
}
