using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class updateMDP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEtM0G8yJiz5QPiNu4bkpQyhQcMtPWB0EkxiCNV2IGqjriKU7WLoDwvBr6uCjH1+Fg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5c068548-92d2-4cf2-8183-94e9e32c0783", "6fe6301a-c18e-4d28-b7c5-9d5f07d39d86" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPqs9YhJNc2LLX64YFuZBfk118raeBO2LgwoOk9pd2qao2NTc3pdaH1utgvRyA8ISA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8035ad15-290c-49e6-85c4-4f01b88ed592", "830a35e6-4ae8-4450-9771-80b0ed3e5023" });
        }
    }
}
