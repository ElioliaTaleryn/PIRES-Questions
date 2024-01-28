using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddPreset_Questionschoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e994d681-fd0b-4e94-9813-3c4f5802b54f", "c9ad865b-d3a1-4988-8d4c-5e4b12634a2b" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "FormId", "Label", "TimerCDId" },
                values: new object[,]
                {
                    { 1, "Choose one answer", 2, "Do you like Paris ?", null },
                    { 2, "Choose one answer", 2, "How much?", 1 }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "Label", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Yes", 1 },
                    { 2, "No", 1 },
                    { 3, "Unconcerned", 1 },
                    { 4, "0", 2 },
                    { 5, "1", 2 },
                    { 6, "2", 2 },
                    { 7, "3", 2 },
                    { 8, "4", 2 },
                    { 9, "5", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6fd69289-5ed6-41f0-a960-6858bb699843", "dc2b7c6e-55df-4416-9115-bd3ea3ec2489" });
        }
    }
}
