using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiosk.Migrations
{
    /// <inheritdoc />
    public partial class FixingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SuppliersID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SuppliersID",
                table: "Products",
                newName: "SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SuppliersID",
                table: "Products",
                newName: "IX_Products_SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierID",
                table: "Products",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Products",
                newName: "SuppliersID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                newName: "IX_Products_SuppliersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SuppliersID",
                table: "Products",
                column: "SuppliersID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
