using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenHauseMonitor.Migrations
{
    public partial class removequesttoSuer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestToUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UsertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestToUsers_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestToUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestToUsers_QuestId",
                table: "QuestToUsers",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestToUsers_UserId",
                table: "QuestToUsers",
                column: "UserId");
        }
    }
}
