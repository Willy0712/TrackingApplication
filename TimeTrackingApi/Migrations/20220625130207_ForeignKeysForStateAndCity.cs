using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    public partial class ForeignKeysForStateAndCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Countryid",
                table: "State",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Stateid",
                table: "City",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_Countryid",
                table: "State",
                column: "Countryid");

            migrationBuilder.CreateIndex(
                name: "IX_City_Stateid",
                table: "City",
                column: "Stateid");

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_Stateid",
                table: "City",
                column: "Stateid",
                principalTable: "State",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_Countryid",
                table: "State",
                column: "Countryid",
                principalTable: "Country",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_Stateid",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_Countryid",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_Countryid",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_City_Stateid",
                table: "City");

            migrationBuilder.DropColumn(
                name: "Countryid",
                table: "State");

            migrationBuilder.DropColumn(
                name: "Stateid",
                table: "City");
        }
    }
}
