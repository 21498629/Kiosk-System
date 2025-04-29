using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiosk.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f4b200a0-c5c0-459f-a678-80eb073ed6aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4b1dd2ee-660a-4d32-adae-a42521cbd713");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "db9cebdc-44e1-40e3-8ae8-7d38b47cb35c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "judfs-dsfdkbfsde-fvsdjklbn", "AQAAAAIAAYagAAAAEOzUnSHz2sJdet/6oecL1xrPBeSq6lOk3J2HRRucziXplSh4mLPXx3ia3u4cLnLj4g==", "dheu48yu9jb sk-0efojrf-basdckj" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "59dfe680-9be4-4485-86ef-77c661f63b3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6fa03aa2-6665-4490-9d8b-7ad8ba47d72b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "3d41617a-4d33-4140-a62c-661aeea45989");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9203039b-73b5-497f-b353-d1d8fc4a9aff", "AQAAAAIAAYagAAAAEE7QPqiftvXvciNq0kPgF+Mdav3rzYccIjyn74kH2NYtO3OqRCkt1vn5Q2o2IWSMcg==", "599066dc-232a-4da1-95d4-2034f9677f09" });
        }
    }
}
