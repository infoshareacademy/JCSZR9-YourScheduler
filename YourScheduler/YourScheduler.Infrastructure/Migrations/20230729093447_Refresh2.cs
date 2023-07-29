using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Refresh2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AOGnNxt9gE15pi+ZMWWj+Vu7k1NIlDPFl5wg+32SnQyF7qcAWVwqVAXv818L6UqnoA==", "FSEA7D6HQBKHHFGSFXXPMKEU64H2RFWR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "APapdT5yP+ozCP9Xhq0PQ7E0X1rJns3zFsR7Izcixqu41Lg/WmC+nyu3f8YWCeJq4Q==", "PWI33Z4FVMK6XF6ZVM5IDIJ6VIMASRWI" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AETd31ke32K7aSNljAigYgTJJvrnJcR3mRP9Ctg/3OvZ86WEFGm/qqllRT2ap9YFSA==", "6RVJRC2A7QDMSID6VZKYFZLD464TC4HC" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AGLXVqhZ4VgqxH5qzMiiVh+V4leFdtVcoVOL33X9MBv5TMiOqCWiQPh6FE9i0FamLQ==", "DMYWP22XJLRDGTMWXGNGGTDFXRQJ7O3P" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AMQ5LW/poopUSrc1FZe/xKbjph6t9VT7VAmwqLVzkSJNHz0pDpJX7m10FS0YMF8Wzw==", "AHYC57KGOP7UAVWXS6B4M57ABLZ7EL5O" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "ABbRaghHytj3EB2t/a5qiLcJrbSPCApsKtRB0/I1We0toxOOZGWe5UZNJxiZOx66ig==", "JJT2TWFD5W246SHQNI3QQSFE4AE5SW36" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
