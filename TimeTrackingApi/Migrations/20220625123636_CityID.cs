using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    public partial class CityID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Cityid",
                table: "Tracking",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_Cityid",
                table: "Tracking",
                column: "Cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracking_City_Cityid",
                table: "Tracking",
                column: "Cityid",
                principalTable: "City",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracking_City_Cityid",
                table: "Tracking");

            migrationBuilder.DropIndex(
                name: "IX_Tracking_Cityid",
                table: "Tracking");

            migrationBuilder.DropColumn(
                name: "Cityid",
                table: "Tracking");
        }
    }
}
