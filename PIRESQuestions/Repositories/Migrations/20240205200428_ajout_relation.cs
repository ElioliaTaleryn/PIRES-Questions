using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ajout_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "492d3492-a8df-4ae7-b76c-512c36e1ebe0", "a6cff311-7a58-4a2e-ab60-0fada2d6d4b7" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_FormId",
                table: "Answers",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Forms_FormId",
                table: "Answers",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Forms_FormId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_FormId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Answers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32460c76-64a1-4418-8e25-b74bcea60a2d", "eaee3de4-249f-4fb8-9848-ae70c17500c1" });
        }
    }
}
