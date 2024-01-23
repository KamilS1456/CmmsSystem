using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenHauseMonitor.Migrations
{
    public partial class addquesttouser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Quests_QuestId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Quests_QuestId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_QuestId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_QuestId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "QuestId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "QuestId",
                table: "Equipments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestId",
                table: "Equipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_QuestId",
                table: "Users",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_QuestId",
                table: "Equipments",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Quests_QuestId",
                table: "Equipments",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Quests_QuestId",
                table: "Users",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");
        }
    }
}
