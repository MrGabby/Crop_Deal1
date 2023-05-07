using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal1.Migrations
{
    /// <inheritdoc />
    public partial class onetoMany_invoiceandCrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Userid",
                table: "Invoices",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_Userid",
                table: "Crops",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Users_Userid",
                table: "Crops",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Userid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_Userid",
                table: "Invoices",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Userid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Users_Userid",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_Userid",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_Userid",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Crops_Userid",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Crops");
        }
    }
}
