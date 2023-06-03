using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addednewfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "administratorId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "APnnusAfvRYR9pO4NJS8+OOZWYtKvwVO/su53YWen+Hj4FgQRs0e0NQfQjcKDX/nUg==", "6PIMPDQQUB63B5WHF3K73K4MBYXISY66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AC/AySNd0m+uu5YULGKSOaEtbf/Zw4tEsChOqceCa/KGsiuLQuqw7KJbHZvlvTL6Lg==", "YYZWB7ET2KYGNCWRXIYOAGMTLSEFYPIK" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AB8tMO96qtHQ/nteXHYlj+14DBB+C6ot4VA4um7IQJ90bJU+XDtyJHuJSpLy2UtH8A==", "63ESLCOHG3ATCII2JZN6FQG37G6R3XN5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AEk0U7T8tHrThUT4dZg01XuEdNKTA5LPliLwk5xVylqoMFpwHyWwlf6HvhuNxBuPhQ==", "PEC4JYWSNPBYKMIQEVGVBL5MLK6CY4QT" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AJXATdu46zavlOiNidwsE0HDA6JvWwavI8bwox3lkhk2o1suxiFovtBZ9Ryky9gEJw==", "MKLC45GDZWG27C3OVPEFCEE2SUBIUERN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "APu9Pv5q7aVbzhmxoyXuQKgS4ue2shN/Rx7eX/nXVZ5IzX6f88lQCYWmB4E0kxN15w==", "A6GXA4LEZJ5BX6UMRXJVBK4FCHSLJ5LO" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "administratorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "administratorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                column: "administratorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "administratorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                column: "administratorId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6,
                column: "administratorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 7,
                column: "administratorId",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "administratorId",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AABL8tgoxdEScXoy1miYUMFIo87A/49kDCV6rNijOqfB6/CjgLA5/wWJyEPxvtxwIg==", "HB22IUN4ALIEU6KEBDNUSYURRHCH54ZW" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AFkq6WCyiWWmsop5LAmMgyhHyi6Fk3NbqrR5oYnImebMd/wCn3MUMF1U/bvjzo/WuQ==", "RBG3Y3V7MB2HKEXBQRT7YLOKUCMIDAWL" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AKaAqldHfDIqlAnlErlM7C8ZMvDh0/z0jOrdsAr7TLSzK/+MwmGK4FHzla+FiB1aIg==", "FQW276RVIH244FDDUQRV5NZHIFONK6Q5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AFqkPSTTo3jeXe8gMwAOZNogcC/a+WEHj+I/mGloaaUBLq+sIAh4OpLs38I4u9sDjg==", "I2DYO7JPMPCFOJT36QVWUNS4C3LBV6GT" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AOI6UEQLsqVEE3a3pWLyongEr/unqKsdMKcRAiAbT749ZiwWTGU7LMv3PCDlBw2ohA==", "UK63FTL6NLDSE2OYH4OAPTM3GO564O4A" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AF8WttLPc/VrI/JEh83jg/rso/FfimQC4jbiq3zCgOQM5pK62uWYYSZepzRgPp5/Fw==", "YBIR5FCNR5UIGYIMNABYR76VG653AKNL" });
        }
    }
}
