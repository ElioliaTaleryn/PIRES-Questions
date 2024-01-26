using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class initForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Form_AspNetUsers_UserPersonId",
                table: "Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Form_Categories_CategoryId",
                table: "Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Form_Periods_PeriodId",
                table: "Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Form_Statuses_StatusId",
                table: "Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Form_TimerCD_TimerCDId",
                table: "Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Form_FormId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Form",
                table: "Form");

            migrationBuilder.RenameTable(
                name: "Form",
                newName: "Forms");

            migrationBuilder.RenameIndex(
                name: "IX_Form_UserPersonId",
                table: "Forms",
                newName: "IX_Forms_UserPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Form_TimerCDId",
                table: "Forms",
                newName: "IX_Forms_TimerCDId");

            migrationBuilder.RenameIndex(
                name: "IX_Form_StatusId",
                table: "Forms",
                newName: "IX_Forms_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Form_PeriodId",
                table: "Forms",
                newName: "IX_Forms_PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Form_CategoryId",
                table: "Forms",
                newName: "IX_Forms_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6359cb55-f72d-4dd1-b0fc-6f0492cbb490", "e5f2b769-d1a3-4bab-9c48-c9875b9c38be" });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CategoryId", "Description", "PeriodId", "StatusId", "TimerCDId", "Title", "UserPersonId" },
                values: new object[] { 1, 1, "Questions about cities", 1, 2, null, "Europeans Capitals", "981173f4-7557-4cde-b839-1ac488b30f9f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_AspNetUsers_UserPersonId",
                table: "Forms",
                column: "UserPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Categories_CategoryId",
                table: "Forms",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Periods_PeriodId",
                table: "Forms",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Statuses_StatusId",
                table: "Forms",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_TimerCD_TimerCDId",
                table: "Forms",
                column: "TimerCDId",
                principalTable: "TimerCD",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Forms_FormId",
                table: "Question",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_AspNetUsers_UserPersonId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Categories_CategoryId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Periods_PeriodId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Statuses_StatusId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_TimerCD_TimerCDId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Forms_FormId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Forms",
                newName: "Form");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_UserPersonId",
                table: "Form",
                newName: "IX_Form_UserPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_TimerCDId",
                table: "Form",
                newName: "IX_Form_TimerCDId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_StatusId",
                table: "Form",
                newName: "IX_Form_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_PeriodId",
                table: "Form",
                newName: "IX_Form_PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_CategoryId",
                table: "Form",
                newName: "IX_Form_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Form",
                table: "Form",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "981173f4-7557-4cde-b839-1ac488b30f9f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "db06354b-5dce-4b2a-ba1e-3394cff421a4", "088d810a-6417-41bc-872b-9c4e9d356d5a" });

            migrationBuilder.AddForeignKey(
                name: "FK_Form_AspNetUsers_UserPersonId",
                table: "Form",
                column: "UserPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Form_Categories_CategoryId",
                table: "Form",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Form_Periods_PeriodId",
                table: "Form",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Form_Statuses_StatusId",
                table: "Form",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Form_TimerCD_TimerCDId",
                table: "Form",
                column: "TimerCDId",
                principalTable: "TimerCD",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Form_FormId",
                table: "Question",
                column: "FormId",
                principalTable: "Form",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
