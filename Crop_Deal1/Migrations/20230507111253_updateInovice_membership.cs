using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal1.Migrations
{
    /// <inheritdoc />
    public partial class updateInovice_membership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CropDetails_id",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "Crop_detailid",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Crop_detailid",
                table: "Invoices",
                column: "Crop_detailid");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Crop_details_Crop_detailid",
                table: "Invoices",
                column: "Crop_detailid",
                principalTable: "Crop_details",
                principalColumn: "Crop_detailid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Crop_details_Crop_detailid",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_Crop_detailid",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Crop_detailid",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "CropDetails_id",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
