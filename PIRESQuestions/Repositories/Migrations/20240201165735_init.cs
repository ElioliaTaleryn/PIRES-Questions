using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountDown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ChoiceId = table.Column<int>(type: "int", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Choices_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "Choices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Anonymouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anonymouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anonymouses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anonymouses_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimerCDId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UserPersonId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_UserPersonId",
                        column: x => x.UserPersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forms_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forms_Timers_TimerCDId",
                        column: x => x.TimerCDId,
                        principalTable: "Timers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    TimerCDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Timers_TimerCDId",
                        column: x => x.TimerCDId,
                        principalTable: "Timers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horodatage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ChoiceId = table.Column<int>(type: "int", nullable: false),
                    AnonymousId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Anonymouses_AnonymousId",
                        column: x => x.AnonymousId,
                        principalTable: "Anonymouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Choices_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "Choices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceQuestion",
                columns: table => new
                {
                    ChoicesId = table.Column<int>(type: "int", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceQuestion", x => new { x.ChoicesId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_ChoiceQuestion_Choices_ChoicesId",
                        column: x => x.ChoicesId,
                        principalTable: "Choices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ChoiceId", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "951173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "514a216a-0c07-4ca1-bae7-25b389afc715", new DateOnly(1991, 12, 25), "example@example.com", true, "Michel", "Does", false, null, "EXAMPLE@EXAMPLE.COM", "EXAMPLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEtM0G8yJiz5QPiNu4bkpQyhQcMtPWB0EkxiCNV2IGqjriKU7WLoDwvBr6uCjH1+Fg==", null, false, "2EKLCF5HV2AN7DRFWTAEU5A5MCQ2OOYX", false, "example@example.com" },
                    { "981173f4-7557-4cde-b839-1ac488b30f9f", 0, null, "32460c76-64a1-4418-8e25-b74bcea60a2d", new DateOnly(1991, 12, 25), "john.doe@example.com", false, null, null, false, null, null, null, null, null, false, "eaee3de4-249f-4fb8-9848-ae70c17500c1", false, "JohnDoe" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Yes" },
                    { 2, "No" },
                    { 3, "Unconcerned" },
                    { 4, "0" },
                    { 5, "1" },
                    { 6, "2" },
                    { 7, "3" },
                    { 8, "4" },
                    { 9, "5" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Afghanistan" },
                    { 2, "Albania" },
                    { 3, "Algeria" },
                    { 4, "Andorra" },
                    { 5, "Angola" },
                    { 6, "Antigua" },
                    { 7, "Argentina" },
                    { 8, "Armenia" },
                    { 9, "Australia" },
                    { 10, "Austria" },
                    { 11, "Azerbaijan" },
                    { 12, "Bahamas" },
                    { 13, "Bahrain" },
                    { 14, "Bangladesh" },
                    { 15, "Barbados" },
                    { 16, "Belarus" },
                    { 17, "Belgium" },
                    { 18, "Belize" },
                    { 19, "Benin" },
                    { 20, "Bhutan" },
                    { 21, "Bolivia" },
                    { 22, "Bosnia" },
                    { 23, "Botswana" },
                    { 24, "Brazil" },
                    { 25, "Brunei Darussalam" },
                    { 26, "Bulgaria" },
                    { 27, "Burkina Faso" },
                    { 28, "Burundi" },
                    { 29, "Cambodia" },
                    { 30, "Cameroon" },
                    { 31, "Canada" },
                    { 32, "Cape Verde" },
                    { 33, "Central African Republic" },
                    { 34, "Chad" },
                    { 35, "Chile" },
                    { 36, "China" },
                    { 37, "Colombia" },
                    { 38, "Comoros" },
                    { 39, "Congo (Republic of the)" },
                    { 40, "Costa Rica" },
                    { 41, "Côte d’Ivoire" },
                    { 42, "Croatia" },
                    { 43, "Cuba" },
                    { 44, "Cyprus" },
                    { 45, "Czech RepubliC" },
                    { 46, "Democratic People’s Republic of Korea" },
                    { 47, "Democratic Republic of the Congo" },
                    { 48, "Denmark" },
                    { 49, "Djibouti" },
                    { 50, "Dominica" },
                    { 51, "Dominican Republic" },
                    { 52, "Ecuador" },
                    { 53, "Egypt" },
                    { 54, "El Salvador" },
                    { 55, "Equatorial Guinea" },
                    { 56, "Eritrea" },
                    { 57, "Estonia" },
                    { 58, "Ethiopia" },
                    { 59, "Fiji" },
                    { 60, "Finland" },
                    { 61, "France" },
                    { 62, "Gabon" },
                    { 63, "Gambia" },
                    { 64, "Georgia" },
                    { 65, "Germany" },
                    { 66, "Ghana" },
                    { 67, "Greece" },
                    { 68, "Grenada" },
                    { 69, "Guatemala" },
                    { 70, "Guinea" },
                    { 71, "Guinea-Bissau" },
                    { 72, "Guyana" },
                    { 73, "Haiti" },
                    { 74, "Honduras" },
                    { 75, "Hungary" },
                    { 76, "Iceland" },
                    { 77, "India" },
                    { 78, "Indonesia" },
                    { 79, "Iran" },
                    { 80, "Iraq" },
                    { 81, "Ireland" },
                    { 82, "Israel" },
                    { 83, "Italy" },
                    { 84, "Jamaica" },
                    { 85, "Japan" },
                    { 86, "Jordan" },
                    { 87, "Kazakhstan" },
                    { 88, "Kenya" },
                    { 89, "Kiribati" },
                    { 90, "Kuwait" },
                    { 91, "Kyrgyzstan" },
                    { 92, "Lao People's Democratic Republic" },
                    { 93, "Latvia" },
                    { 94, "Lebanon" },
                    { 95, "Lesotho" },
                    { 96, "Liberia" },
                    { 97, "Libya" },
                    { 98, "Liechtenstein" },
                    { 99, "Lithuania" },
                    { 100, "Luxembourg" },
                    { 101, "Madagascar" },
                    { 102, "Malawi" },
                    { 103, "Malaysia" },
                    { 104, "Maldives" },
                    { 105, "Mali" },
                    { 106, "Malta" },
                    { 107, "Marshall Islands" },
                    { 108, "Mauritania" },
                    { 109, "Mauritius" },
                    { 110, "Mexico" },
                    { 111, "Micronesia (Federated States of)" },
                    { 112, "Monaco" },
                    { 113, "Mongolia" },
                    { 114, "Montenegro" },
                    { 115, "Morocco" },
                    { 116, "Mozambique" },
                    { 117, "Myanmar" },
                    { 118, "Namibia" },
                    { 119, "Nauru" },
                    { 120, "Nepal" },
                    { 121, "Netherlands" },
                    { 122, "New Zealand" },
                    { 123, "Nicaragua" },
                    { 124, "Niger" },
                    { 125, "Nigeria" },
                    { 126, "Norway" },
                    { 127, "Oman" },
                    { 128, "Pakistan" },
                    { 129, "Palau" },
                    { 130, "Panama" },
                    { 131, "Papua New Guinea" },
                    { 132, "Paraguay" },
                    { 133, "Peru" },
                    { 134, "Philippines" },
                    { 135, "Poland" },
                    { 136, "Portugal" },
                    { 137, "Qatar" },
                    { 138, "Republic of Korea" },
                    { 139, "Republic of Moldova" },
                    { 140, "Romania" },
                    { 141, "Russian Federation" },
                    { 142, "Rwanda" },
                    { 143, "Saint Kitts and Nevis" },
                    { 144, "Saint Lucia" },
                    { 145, "Saint Vincent and the Grenadines" },
                    { 146, "Samoa" },
                    { 147, "San Marino" },
                    { 148, "Sao Tome and Principe" },
                    { 149, "Saudi Arabia" },
                    { 150, "Senegal" },
                    { 151, "Serbia" },
                    { 152, "Seychelles" },
                    { 153, "Sierra Leone" },
                    { 154, "Singapore" },
                    { 155, "Slovakia" },
                    { 156, "Slovenia" },
                    { 157, "Solomon Islands" },
                    { 158, "Somalia" },
                    { 159, "South Africa" },
                    { 160, "Spain" },
                    { 161, "Sri Lanka" },
                    { 162, "Sudan" },
                    { 163, "Suriname" },
                    { 164, "Swaziland" },
                    { 165, "Switzerland" },
                    { 166, "Sweden" },
                    { 167, "Syria" },
                    { 168, "Tajikistan" },
                    { 169, "Thailand" },
                    { 170, "The former Yugoslav Republic of Macedonia" },
                    { 171, "Timor Leste" },
                    { 172, "Togo" },
                    { 173, "Tonga" },
                    { 174, "Trinidad and Tobago" },
                    { 175, "Tunisia" },
                    { 176, "Turkey" },
                    { 177, "Turkmenistan" },
                    { 178, "Tuvalu" },
                    { 179, "Uganda" },
                    { 180, "Ukraine" },
                    { 181, "United Arab Emirates" },
                    { 182, "United Kingdom" },
                    { 183, "United of Republic of Tanzania" },
                    { 184, "United States" },
                    { 185, "Uruguay" },
                    { 186, "Uzbekistan" },
                    { 187, "Vanuatu" },
                    { 188, "Venezuela" },
                    { 189, "Viet Nam" },
                    { 190, "Yemen" },
                    { 191, "Zambia" },
                    { 192, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Woman" },
                    { 2, "Man" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "In progress" },
                    { 2, "Validated" },
                    { 3, "Archived" }
                });

            migrationBuilder.InsertData(
                table: "Timers",
                columns: new[] { "Id", "CountDown" },
                values: new object[,]
                {
                    { 1, 30 },
                    { 2, 60 },
                    { 3, 90 },
                    { 4, 120 }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Description", "StatusId", "TimerCDId", "Title", "UserPersonId" },
                values: new object[,]
                {
                    { 1, "Questions about cities", 1, null, "Europeans Capitals", "981173f4-7557-4cde-b839-1ac488b30f9f" },
                    { 2, "Questions about cities v2", 2, null, "Europeans Capitals", "951173f4-7557-4cde-b839-1ac488b30f9f" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "FormId", "Label", "TimerCDId" },
                values: new object[,]
                {
                    { 1, "Choose one answer", 2, "Do you like Paris ?", null },
                    { 2, "Choose one answer", 2, "How much?", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anonymouses_CountryId",
                table: "Anonymouses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Anonymouses_GenderId",
                table: "Anonymouses",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnonymousId",
                table: "Answers",
                column: "AnonymousId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ChoiceId",
                table: "Answers",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChoiceId",
                table: "AspNetUsers",
                column: "ChoiceId");

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

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceQuestion_QuestionsId",
                table: "ChoiceQuestion",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_StatusId",
                table: "Forms",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_TimerCDId",
                table: "Forms",
                column: "TimerCDId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserPersonId",
                table: "Forms",
                column: "UserPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FormId",
                table: "Questions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TimerCDId",
                table: "Questions",
                column: "TimerCDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChoiceQuestion");

            migrationBuilder.DropTable(
                name: "Anonymouses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Timers");

            migrationBuilder.DropTable(
                name: "Choices");
        }
    }
}
