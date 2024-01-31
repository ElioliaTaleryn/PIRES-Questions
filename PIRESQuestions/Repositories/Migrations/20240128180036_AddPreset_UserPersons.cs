using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddPreset_UserPersons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ChoiceId", "ConcurrencyStamp", "CountryId", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "GenderId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "951173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "514a216a-0c07-4ca1-bae7-25b389afc715", 1, new DateOnly(1991, 12, 25), "example@example.com", true, "Michel", 2, "Does", false, null, "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEtM0G8yJiz5QPiNu4bkpQyhQcMtPWB0EkxiCNV2IGqjriKU7WLoDwvBr6uCjH1+Fg==", null, false, "2EKLCF5HV2AN7DRFWTAEU5A5MCQ2OOYX", false, "example@example.com" },
                    { "981173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "78659ef5-2eb1-4429-901f-39599c57d589", 1, new DateOnly(1991, 12, 25), "john.doe@example.com", false, "Michel", 2, "Does", false, null, null, null, null, null, false, "b52e933b-8c0e-43b6-be85-96538354bb84", false, "JohnDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f");
        }
    }
}
