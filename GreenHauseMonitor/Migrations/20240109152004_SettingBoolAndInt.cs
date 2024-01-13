using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenHauseMonitor.Migrations
{
    public partial class SettingBoolAndInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingToRoles");

            migrationBuilder.DropTable(
                name: "SettingToUsers");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Settings",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValueType",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SettingValueBools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<bool>(type: "bit", nullable: false),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingValueBools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingValueBools_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SettingValueBools_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingValueBools_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SettingValueInts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingValueInts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingValueInts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SettingValueInts_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingValueInts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettingValueBools_RoleId",
                table: "SettingValueBools",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingValueBools_SettingId",
                table: "SettingValueBools",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingValueBools_UserId",
                table: "SettingValueBools",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingValueInts_RoleId",
                table: "SettingValueInts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingValueInts_SettingId",
                table: "SettingValueInts",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingValueInts_UserId",
                table: "SettingValueInts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingValueBools");

            migrationBuilder.DropTable(
                name: "SettingValueInts");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ValueType",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Settings",
                newName: "Type");

            migrationBuilder.CreateTable(
                name: "SettingToRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    SettingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingToRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingToRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingToRoles_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingToUsers_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingToUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettingToRoles_RoleId",
                table: "SettingToRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingToRoles_SettingId",
                table: "SettingToRoles",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingToUsers_SettingId",
                table: "SettingToUsers",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingToUsers_UserId",
                table: "SettingToUsers",
                column: "UserId");
        }
    }
}
