using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmms.Migrations
{
    public partial class eqtoequpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToEquipment_Equipments_InnerEquipmentId",
                table: "EquipmentToEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToEquipment_Equipments_PrimalEquipmentId",
                table: "EquipmentToEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentToEquipment",
                table: "EquipmentToEquipment");

            migrationBuilder.RenameTable(
                name: "EquipmentToEquipment",
                newName: "EquipmentToEquipments");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentToEquipment_PrimalEquipmentId",
                table: "EquipmentToEquipments",
                newName: "IX_EquipmentToEquipments_PrimalEquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentToEquipments",
                table: "EquipmentToEquipments",
                columns: new[] { "InnerEquipmentId", "PrimalEquipmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToEquipments_Equipments_InnerEquipmentId",
                table: "EquipmentToEquipments",
                column: "InnerEquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToEquipments_Equipments_PrimalEquipmentId",
                table: "EquipmentToEquipments",
                column: "PrimalEquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToEquipments_Equipments_InnerEquipmentId",
                table: "EquipmentToEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToEquipments_Equipments_PrimalEquipmentId",
                table: "EquipmentToEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentToEquipments",
                table: "EquipmentToEquipments");

            migrationBuilder.RenameTable(
                name: "EquipmentToEquipments",
                newName: "EquipmentToEquipment");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentToEquipments_PrimalEquipmentId",
                table: "EquipmentToEquipment",
                newName: "IX_EquipmentToEquipment_PrimalEquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentToEquipment",
                table: "EquipmentToEquipment",
                columns: new[] { "InnerEquipmentId", "PrimalEquipmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToEquipment_Equipments_InnerEquipmentId",
                table: "EquipmentToEquipment",
                column: "InnerEquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToEquipment_Equipments_PrimalEquipmentId",
                table: "EquipmentToEquipment",
                column: "PrimalEquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");
        }
    }
}
