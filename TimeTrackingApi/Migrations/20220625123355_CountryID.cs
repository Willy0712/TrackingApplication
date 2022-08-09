using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    public partial class CountryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Countryid",
                table: "Tracking",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_Countryid",
                table: "Tracking",
                column: "Countryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracking_Country_Countryid",
                table: "Tracking",
                column: "Countryid",
                principalTable: "Country",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracking_Country_Countryid",
                table: "Tracking");

            migrationBuilder.DropIndex(
                name: "IX_Tracking_Countryid",
                table: "Tracking");

            migrationBuilder.DropColumn(
                name: "Countryid",
                table: "Tracking");
        }
    }
}
