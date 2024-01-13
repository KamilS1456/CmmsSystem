using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenHauseMonitor.Migrations
{
    public partial class AddEntityBaseAndSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifyByUserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifyDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifyByUserId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifyDateTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifyByUserId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifyDateTime",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingToRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingToRoles");

            migrationBuilder.DropTable(
                name: "SettingToUsers");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifyByUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifyDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifyByUserId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifyDateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LastModifyByUserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LastModifyDateTime",
                table: "Restaurants");
        }
    }
}
