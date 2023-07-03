using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class addingnormalizedsuper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c1a2688-a0f5-4906-a220-d9acc9ec6072",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3145258c-ed28-41d1-9971-6f3570fd1785", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAEAACcQAAAAEKFCLMsU6HiPiWyQI2rQ4PR/9ILUmXWDZKp1jyUvqEBtD7SYtAAMIGWkn+KEKoafEw==", "0bdf1f34-5b6d-403b-b7ba-ee927e2d8867", "superadmin@bloggie.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c1a2688-a0f5-4906-a220-d9acc9ec6072",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ed8de2c6-79c1-4441-abd3-5e4425050b9c", null, null, "AQAAAAIAAYagAAAAEASlz7ZrHqcDBJpBoQ2lCH1pNBBequx87dVjA6Z2Zy+aRGZhaWfOxck+eksCL9Ln0A==", "e77a6ae7-b6c2-48ec-bc88-cecdaf520252", "Ollegorn" });
        }
    }
}
