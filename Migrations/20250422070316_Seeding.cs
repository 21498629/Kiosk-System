using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiosk.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "kgbasdcsfv-dasdjgbf-ascfb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "kjdbhszf-sdflobnljfc-fszdnvd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ljsdhfv-lkjbhdfs-kjbhdsueh");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhysicalAddress", "SecurityStamp", "SignupDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4e5f6g7-8h9i-0j1k-2l3m-a4e5f6g7h8i9", 0, "judfs-dsfdkbfsde-fvsdjklbn", "admin@admin.com", false, false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEI6SvcfAYWbmjT1X9EViDpDjyHXIa0WOBWInexSSWWyZc2m4VObVFUeyUiOc90j8Fw==", "0123456789", false, "Admin", "dheu48yu9jb sk-0efojrf-basdckj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "a4e5f6g7-8h9i-0j1k-2l3m-a4e5f6g7h8i9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a4e5f6g7-8h9i-0j1k-2l3m-a4e5f6g7h8i9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4e5f6g7-8h9i-0j1k-2l3m-a4e5f6g7h8i9");

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhysicalAddress", "SecurityStamp", "SignupDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "judfs-dsfdkbfsde-fvsdjklbn", "admin@admin.com", false, false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEOzUnSHz2sJdet/6oecL1xrPBeSq6lOk3J2HRRucziXplSh4mLPXx3ia3u4cLnLj4g==", "0123456789", false, "Admin", "dheu48yu9jb sk-0efojrf-basdckj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }
    }
}
