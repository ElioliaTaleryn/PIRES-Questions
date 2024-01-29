using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class DbContext_mis_a_jour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Anonymous_AnonymousId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anonymous",
                table: "Anonymous");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Anonymous",
                newName: "Anonymouses");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Anonymouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Anonymouses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Anonymouses",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anonymouses",
                table: "Anonymouses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Anonymouses",
                columns: new[] { "Id", "Age", "CountryId", "GenderId" },
                values: new object[,]
                {
                    { 1, 18, null, null },
                    { 2, 60, null, null },
                    { 3, 36, null, null },
                    { 4, 42, null, null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f",
                column: "CountryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "CountryId", "FirstName", "LastName", "SecurityStamp" },
                values: new object[] { "ce3e6bf0-1a0b-4f5b-8822-9165d907c101", null, null, null, "a4dd2916-9b82-4c60-b552-e7fe605b2fcf" });

            migrationBuilder.CreateIndex(
                name: "IX_Anonymouses_CountryId",
                table: "Anonymouses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Anonymouses_GenderId",
                table: "Anonymouses",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anonymouses_Countries_CountryId",
                table: "Anonymouses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Anonymouses_Genders_GenderId",
                table: "Anonymouses",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Anonymouses_AnonymousId",
                table: "Answers",
                column: "AnonymousId",
                principalTable: "Anonymouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anonymouses_Countries_CountryId",
                table: "Anonymouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Anonymouses_Genders_GenderId",
                table: "Anonymouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Anonymouses_AnonymousId",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anonymouses",
                table: "Anonymouses");

            migrationBuilder.DropIndex(
                name: "IX_Anonymouses_CountryId",
                table: "Anonymouses");

            migrationBuilder.DropIndex(
                name: "IX_Anonymouses_GenderId",
                table: "Anonymouses");

            migrationBuilder.DeleteData(
                table: "Anonymouses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Anonymouses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Anonymouses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Anonymouses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Anonymouses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Anonymouses");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Anonymouses");

            migrationBuilder.RenameTable(
                name: "Anonymouses",
                newName: "Anonymous");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anonymous",
                table: "Anonymous",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "CountryId", "GenderId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "CountryId", "FirstName", "GenderId", "LastName", "SecurityStamp" },
                values: new object[] { "9aac156b-50d9-4de6-97b4-49dff7079779", 1, "Michel", 2, "Does", "ea545996-af8a-4289-8a9b-799b05ecaf4f" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Anonymous_AnonymousId",
                table: "Answers",
                column: "AnonymousId",
                principalTable: "Anonymous",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");
        }
    }
}
