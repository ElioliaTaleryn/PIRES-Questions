using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddPreset_Forms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6fd69289-5ed6-41f0-a960-6858bb699843", "dc2b7c6e-55df-4416-9115-bd3ea3ec2489" });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Description", "StatusId", "TimerCDId", "Title", "UserPersonId" },
                values: new object[,]
                {
                    { 1, "Questions about cities", 1, null, "Europeans Capitals", "981173f4-7557-4cde-b839-1ac488b30f9f" },
                    { 2, "Questions about cities v2", 2, null, "Europeans Capitals", "951173f4-7557-4cde-b839-1ac488b30f9f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78659ef5-2eb1-4429-901f-39599c57d589", "b52e933b-8c0e-43b6-be85-96538354bb84" });
        }
    }
}
