using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class initQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Question_QuestionId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Forms_FormId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_TimerCD_TimerCDId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TimerCDId",
                table: "Questions",
                newName: "IX_Questions_TimerCDId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_FormId",
                table: "Questions",
                newName: "IX_Questions_FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
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

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "FormId", "Label", "TimerCDId" },
                values: new object[,]
                {
                    { 1, "choose 1 reply", 2, "Witch city is the French Capital", null },
                    { 2, "choose 1 reply", 2, "What is the color of the sky", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Questions_QuestionId",
                table: "Choice",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Forms_FormId",
                table: "Questions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_TimerCD_TimerCDId",
                table: "Questions",
                column: "TimerCDId",
                principalTable: "TimerCD",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Questions_QuestionId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Forms_FormId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_TimerCD_TimerCDId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TimerCDId",
                table: "Question",
                newName: "IX_Question_TimerCDId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_FormId",
                table: "Question",
                newName: "IX_Question_FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN8CfWXgruZxmIpW2NE+9xGiDIaG6v5/rleuDizt/0/6BKEOEx8wvSQfT9wwqCHZeA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "15778175-9290-479e-8545-b36ac20ecef3", "8dd527be-b305-401b-b378-a732d65b6b6f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Question_QuestionId",
                table: "Choice",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Forms_FormId",
                table: "Question",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_TimerCD_TimerCDId",
                table: "Question",
                column: "TimerCDId",
                principalTable: "TimerCD",
                principalColumn: "Id");
        }
    }
}
