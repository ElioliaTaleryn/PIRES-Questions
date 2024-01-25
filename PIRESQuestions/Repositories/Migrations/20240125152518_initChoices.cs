using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class initChoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Choice_ChoiceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Questions_QuestionId",
                table: "Choice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choice",
                table: "Choice");

            migrationBuilder.RenameTable(
                name: "Choice",
                newName: "Choices");

            migrationBuilder.RenameIndex(
                name: "IX_Choice_QuestionId",
                table: "Choices",
                newName: "IX_Choices_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choices",
                table: "Choices",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "Label", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Paris", 1 },
                    { 2, "Bordeau", 1 },
                    { 3, "Red", 2 },
                    { 4, "Cyan", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Choices_ChoiceId",
                table: "AspNetUsers",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Choices_ChoiceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choices",
                table: "Choices");

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

            migrationBuilder.RenameTable(
                name: "Choices",
                newName: "Choice");

            migrationBuilder.RenameIndex(
                name: "IX_Choices_QuestionId",
                table: "Choice",
                newName: "IX_Choice_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choice",
                table: "Choice",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECt+Tavvckgzk8i2XV4w9sXmei2UNtt6xVX7YtwKzZV/hRIqz9kA5S4knijNl4UWug==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "45ab3d9d-3651-4b67-9d00-9528bbd77d4f", "60c98068-a08b-4b37-868c-7b83d7b6049e" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Choice_ChoiceId",
                table: "AspNetUsers",
                column: "ChoiceId",
                principalTable: "Choice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Questions_QuestionId",
                table: "Choice",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
