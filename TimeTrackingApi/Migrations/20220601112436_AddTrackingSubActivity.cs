using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTrackingApi.Migrations
{
    public partial class AddTrackingSubActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubActivity",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberOfHours = table.Column<long>(type: "bigint", nullable: false),
                    Dificulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parentid = table.Column<long>(type: "bigint", nullable: true),
                    SubActivityid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubActivity", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubActivity_SubActivity_SubActivityid",
                        column: x => x.SubActivityid,
                        principalTable: "SubActivity",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SubActivity_Tracking_Parentid",
                        column: x => x.Parentid,
                        principalTable: "Tracking",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubActivity_Parentid",
                table: "SubActivity",
                column: "Parentid");

            migrationBuilder.CreateIndex(
                name: "IX_SubActivity_SubActivityid",
                table: "SubActivity",
                column: "SubActivityid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubActivity");
        }
    }
}
