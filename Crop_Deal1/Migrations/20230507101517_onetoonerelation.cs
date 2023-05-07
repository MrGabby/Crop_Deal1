using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal1.Migrations
{
    /// <inheritdoc />
    public partial class onetoonerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Crop_detailid",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Bank_details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crops_Crop_detailid",
                table: "Crops",
                column: "Crop_detailid");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_details_Userid",
                table: "Bank_details",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank_details_Users_Userid",
                table: "Bank_details",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Crop_details_Crop_detailid",
                table: "Crops",
                column: "Crop_detailid",
                principalTable: "Crop_details",
                principalColumn: "Crop_detailid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank_details_Users_Userid",
                table: "Bank_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Crop_details_Crop_detailid",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_Crop_detailid",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Bank_details_Userid",
                table: "Bank_details");

            migrationBuilder.DropColumn(
                name: "Crop_detailid",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Bank_details");
        }
    }
}
