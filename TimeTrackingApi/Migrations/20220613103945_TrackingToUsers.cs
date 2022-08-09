using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    public partial class TrackingToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Parentid",
                table: "Tracking",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_Parentid",
                table: "Tracking",
                column: "Parentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracking_Users_Parentid",
                table: "Tracking",
                column: "Parentid",
                principalTable: "Users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracking_Users_Parentid",
                table: "Tracking");

            migrationBuilder.DropIndex(
                name: "IX_Tracking_Parentid",
                table: "Tracking");

            migrationBuilder.DropColumn(
                name: "Parentid",
                table: "Tracking");
        }
    }
}
