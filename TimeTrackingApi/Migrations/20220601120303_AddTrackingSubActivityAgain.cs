using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    public partial class AddTrackingSubActivityAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubActivity_SubActivity_SubActivityid",
                table: "SubActivity");

            migrationBuilder.DropIndex(
                name: "IX_SubActivity_SubActivityid",
                table: "SubActivity");

            migrationBuilder.DropColumn(
                name: "SubActivityid",
                table: "SubActivity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SubActivityid",
                table: "SubActivity",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubActivity_SubActivityid",
                table: "SubActivity",
                column: "SubActivityid");

            migrationBuilder.AddForeignKey(
                name: "FK_SubActivity_SubActivity_SubActivityid",
                table: "SubActivity",
                column: "SubActivityid",
                principalTable: "SubActivity",
                principalColumn: "id");
        }
    }
}
