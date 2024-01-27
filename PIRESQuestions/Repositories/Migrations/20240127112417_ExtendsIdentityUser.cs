using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ExtendsIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp", "UserName" },
                values: new object[] { "347043a5-a577-4f55-9888-f986ecfe9725", "john.doe@example.com", "90860f85-c709-445e-9ad7-1aa9f3af944c", "JohnDoe" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951173f4-7557-4cde-b839-1ac488b30f9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ChoiceId", "ConcurrencyStamp", "CountryId", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "951173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "514a216a-0c07-4ca1-bae7-25b389afc715", 1, new DateOnly(1991, 12, 25), "UserPerson", "example@example.com", true, "Michel", 2, "Does", false, null, "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEtM0G8yJiz5QPiNu4bkpQyhQcMtPWB0EkxiCNV2IGqjriKU7WLoDwvBr6uCjH1+Fg==", null, false, "2EKLCF5HV2AN7DRFWTAEU5A5MCQ2OOYX", false, "example@example.com" },
                    { "981173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "7fe8d6e5-960b-4e82-96dd-c467b3eab44c", 1, new DateOnly(1991, 12, 25), "UserPerson", null, false, "Michel", 2, "Does", false, null, null, null, null, null, false, "5bbe6a3f-1d17-49c0-87f0-70d05c948757", false, null }
                });
        }
    }
}
