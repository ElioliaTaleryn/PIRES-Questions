using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class addUserWithLogAndAForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "15778175-9290-479e-8545-b36ac20ecef3", "8dd527be-b305-401b-b378-a732d65b6b6f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ChoiceId", "ConcurrencyStamp", "CountryId", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "951173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "514a216a-0c07-4ca1-bae7-25b389afc715", 1, new DateOnly(1991, 12, 25), "UserPerson", "example@example.com", false, "Michel", 2, "Does", false, null, "EXAMPLE@EXAMPLE.COM", "BOB", "AQAAAAIAAYagAAAAEN8CfWXgruZxmIpW2NE+9xGiDIaG6v5/rleuDizt/0/6BKEOEx8wvSQfT9wwqCHZeA==", null, false, "2EKLCF5HV2AN7DRFWTAEU5A5MCQ2OOYX", false, "bob" });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CategoryId", "Description", "PeriodId", "StatusId", "TimerCDId", "Title", "UserPersonId" },
                values: new object[] { 2, 1, "Questions about cities v2", 1, 2, null, "Europeans Capitals", "951173f4-7557-4cde-b839-1ac488b30f9f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6359cb55-f72d-4dd1-b0fc-6f0492cbb490", "e5f2b769-d1a3-4bab-9c48-c9875b9c38be" });
        }
    }
}
