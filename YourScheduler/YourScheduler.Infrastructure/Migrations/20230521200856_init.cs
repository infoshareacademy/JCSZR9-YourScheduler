﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourScheduler.Infrastructure.Migrations
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Displayname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "ApplicationUsersEvents",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersEvents", x => new { x.ApplicationUserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersEvents_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsersTeams",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersTeams", x => new { x.ApplicationUserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersTeams_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Displayname", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "", "admin", "admin@gmail.com", false, true, null, "admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AABL8tgoxdEScXoy1miYUMFIo87A/49kDCV6rNijOqfB6/CjgLA5/wWJyEPxvtxwIg==", "111 222 333", false, "HB22IUN4ALIEU6KEBDNUSYURRHCH54ZW", "admin", false, "admin@gmail.com" },
                    { 2, 0, "", "kjarzyna", "jarzyna@gmail.com", false, true, null, "Krzysztof", "JARZYNA@GMAIL.COM", "JARZYNA@GMAIL.COM", "AFkq6WCyiWWmsop5LAmMgyhHyi6Fk3NbqrR5oYnImebMd/wCn3MUMF1U/bvjzo/WuQ==", "666 598 456", false, "RBG3Y3V7MB2HKEXBQRT7YLOKUCMIDAWL", "Jarzyna", false, "jarzyna@gmail.com" },
                    { 3, 0, "", "Jane", "jane_johnson@gmail.com", false, true, null, "Jane", "JANE_JOHNSON@GMAIL.COM", "JANE_JOHNSON@GMAIL.COM", "AKaAqldHfDIqlAnlErlM7C8ZMvDh0/z0jOrdsAr7TLSzK/+MwmGK4FHzla+FiB1aIg==", "666 598 456", false, "FQW276RVIH244FDDUQRV5NZHIFONK6Q5", "Johnson", false, "jane_johnson@gmail.com" },
                    { 4, 0, "", "willmich", "michaelww@gmail.com", false, true, null, "Michael", "MICHAELWW@GMAIL.COM", "MICHAELWW@GMAIL.COM", "AFqkPSTTo3jeXe8gMwAOZNogcC/a+WEHj+I/mGloaaUBLq+sIAh4OpLs38I4u9sDjg==", "987 654 321", false, "I2DYO7JPMPCFOJT36QVWUNS4C3LBV6GT", "Williams", false, "michaelww@gmail.com" },
                    { 5, 0, "", "william", "joneswilliam@gmail.com", false, true, null, "William", "JONESWILLIAM@GMAIL.COM", "JONESWILLIAM@GMAIL.COM", "AOI6UEQLsqVEE3a3pWLyongEr/unqKsdMKcRAiAbT749ZiwWTGU7LMv3PCDlBw2ohA==", "123 456 789", false, "UK63FTL6NLDSE2OYH4OAPTM3GO564O4A", "Jones", false, "joneswilliam@gmail.com" },
                    { 6, 0, "", "brownie", "oliviab@gmail.com", false, true, null, "Olivia", "OLIVIAB@GMAIL.COM", "OLIVIAB@GMAIL.COM", "AF8WttLPc/VrI/JEh83jg/rso/FfimQC4jbiq3zCgOQM5pK62uWYYSZepzRgPp5/Fw==", "666 598 456", false, "YBIR5FCNR5UIGYIMNABYR76VG653AKNL", "Brown", false, "oliviab@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Date", "Description", "IsOpen", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koncert z okazji urodzin TVP", true, "Koncert Zenka Martyniuka" },
                    { 2, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wyjątkowe spotkanie z autorami bestsellerowych książek", true, "Spotkanie Literackie: Autorzy Bestsellerów" },
                    { 3, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spektakl muzyczny pełen magii i emocji", true, "Występ Teatru Muzycznego: Magiczna Melodia" },
                    { 4, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Najnowsze trendy i innowacje technologiczne na światowym poziomie", true, "Konferencja Technologiczna: Przyszłość Innowacji" },
                    { 5, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Przyjemny wieczór filmowy z wyjątkowymi produkcjami z całego świata", false, "Sesja Filmowa: Kino bez Granic" },
                    { 6, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wyjątkowy pokaz kulinarny, podczas którego można odkryć smaki z różnych zakątków świata", false, "Pokaz Kulinarny: Świat Smaków" },
                    { 7, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niezwykłe przedstawienie teatralne pełne emocji i wrażeń", true, "Sztuka na Scenie: Wieczór Teatru" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Grupa szkółki pływackiej Argonaut", "Grupa początkująca basen Chełm" },
                    { 2, "Grupa zrzeszająca mieszkańców osiedla Lawendowe Wzgórze w Gdańsku", "Mieszkańcy osiedla Lawendowe Wzgórze" },
                    { 3, "Zapraszamy do naszego kreatywnego warsztatu artystycznego, gdzie możesz rozwijać swoje umiejętności w różnych dziedzinach sztuki.", "Kreatywny Warsztat Artystyczny" },
                    { 4, "Dołącz do naszego klubu fitness i wellness, gdzie możesz ćwiczyć, relaksować się i dbać o swoje zdrowie pod okiem profesjonalnych instruktorów.", "Klub Fitness i Wellness" },
                    { 5, "Zapraszamy do naszego klubu fotograficznego, gdzie pasjonaci fotografii mogą się spotkać, dzielić się wiedzą i rozwijać swoje umiejętności fotograficzne.", "Klub Fotograficzny Obiektyw" },
                    { 6, "Nasze studio tańca Ritmo oferuje różnorodne style taneczne dla osób w każdym wieku, bez względu na poziom zaawansowania.", "Studio Tańca Ritmo" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsersEvents",
                columns: new[] { "ApplicationUserId", "EventId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 5 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsersTeams",
                columns: new[] { "ApplicationUserId", "TeamId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 6, 5 },
                    { 6, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersEvents_EventId",
                table: "ApplicationUsersEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersTeams_TeamId",
                table: "ApplicationUsersTeams",
                column: "TeamId");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersEvents");

            migrationBuilder.DropTable(
                name: "ApplicationUsersTeams");

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
                name: "Events");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
