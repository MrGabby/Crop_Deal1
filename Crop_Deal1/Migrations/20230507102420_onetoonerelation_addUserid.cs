using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal1.Migrations
{
    /// <inheritdoc />
    public partial class onetoonerelation_addUserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank_details_Users_Userid",
                table: "Bank_details");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "Bank_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bank_details_Users_Userid",
                table: "Bank_details",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Userid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank_details_Users_Userid",
                table: "Bank_details");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "Bank_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank_details_Users_Userid",
                table: "Bank_details",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Userid");
        }
    }
}
