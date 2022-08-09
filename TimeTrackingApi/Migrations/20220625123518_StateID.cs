using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    public partial class StateID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Stateid",
                table: "Tracking",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_Stateid",
                table: "Tracking",
                column: "Stateid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracking_State_Stateid",
                table: "Tracking",
                column: "Stateid",
                principalTable: "State",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracking_State_Stateid",
                table: "Tracking");

            migrationBuilder.DropIndex(
                name: "IX_Tracking_Stateid",
                table: "Tracking");

            migrationBuilder.DropColumn(
                name: "Stateid",
                table: "Tracking");
        }
    }
}
