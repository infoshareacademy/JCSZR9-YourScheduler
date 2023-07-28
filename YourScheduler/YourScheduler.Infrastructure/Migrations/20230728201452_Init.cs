using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AOu06oz5CDw01clwkTNxw2yJGGlY5EOF3jiUiFvTJ/ztpbb2s9WhBUL1zdF6flGxHA==", "BWV76ONH57TBWGJCV2SFNUZYBAAUFEHD" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AA0dPyKeeGx+3SIgWBqKVljQV7Dh9rBUeUJCFBTC41xCz3XyXlJcOjanYsXwiSHu/A==", "2HT6WKNEZSQ3HOAWYGDQEQYLD7B6D6HD" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AFxRI0oybU3pqmqMWNgrVxaBTPoysFkI4uKvJoC882GYOnxG/KH+O2fYd/NcnJHgow==", "W27DKY2EOLYB7LH2FFIPYR7AO4BFCCLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AHO9wOSIS9nob17IG6af/UjPu4XAecgsRCgC69uefIf1xQQVeivz1ZEztNWmKDd2pw==", "D76AVPRNIY7MMMGZMUMGFUZBIUQ6JPLY" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AJw8SQ5yQPh8gTksL487OOSztyJWHJ3Rd7hQtR+WMsczRrQ9IojVPOMRb5CDV4boeQ==", "5R2Q2H4LXKC3HJG2JIQGPKL5CWZJ6DLI" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AJLiiyelA301QNibJ5NjyzMvbGwJyB5pWFQ/G0OhrQYvbbnOpQ79ujlZw6+aOEGVTg==", "QNIFYEDXLWWHJKW36SBPPNI2G3FSDCPG" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "PicturePath",
                value: "/Pictures/pilkarz.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "PicturePath",
                value: "/Pictures/pilkarz.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                column: "PicturePath",
                value: "/Pictures/pilkarz.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "PicturePath",
                value: "/Pictures/pilkarz.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                column: "PicturePath",
                value: "/Pictures/pilkarz.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6,
                column: "PicturePath",
                value: "/Pictures/pilkarz.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 7,
                column: "PicturePath",
                value: "/Pictures/pilkarz.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AG6fGtY/APsQ80sce9ZA2ZjA4wk68+sszqX0wVF8ofb5EG2ofUg9auBmjENd0nqs+Q==", "LXXYO3RDE7JHF5PKJLWM23PCWN6UO2UE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "ANi884TAY7hp9lNGPUGCZhaOmnzFnKpcVa0hubJ5EKuLWE/xMdlVV6EdxsCOzWyX5w==", "F2YAMINQUAQ5D6AARJYCSRM7TVZLOPA6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AIOdP0rYGELserqY8Vg75k2hqbftPc1e5a3ndtth7Fl0tt1JuuLdQuBqo0EK+wbWDg==", "7G6F2ABUBKAJAUE2NN2MD3UHWVZBEXCW" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AG6YrIUPreTHfFMbzanjNNicBgbMvIK9skX+ZXOGAxVfJtpCB644gUmgUKjQsQuGyQ==", "CBIMWTXQKWOLC2ZRUEP4YNANSUZOJXXH" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "APISCNnbvvDU5L2rY/VJ3ZzElRD63GSjV4pGWTyksAYuZokD8dqSZ5vGga54diCbuQ==", "XHJKLN5BLURRE6AWFYGZB64LZGLMT7RX" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AGKZCKKByooc46IQS+BLpJ5uUbEGrh5Mg/GhU6k6CtTpnox36/PuIBzlQ5zjOlDuQQ==", "EJ4TLHB6Y6H7MVZCNTH6SW3MPMMAK67F" });
        }
    }
}
