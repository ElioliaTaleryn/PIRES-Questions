using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class initPersons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ChoiceId", "ConcurrencyStamp", "CountryId", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "981173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "db06354b-5dce-4b2a-ba1e-3394cff421a4", 1, new DateOnly(1991, 12, 25), "UserPerson", null, false, "Michel", 2, "Does", false, null, null, null, null, null, false, "088d810a-6417-41bc-872b-9c4e9d356d5a", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f");
        }
    }
}
