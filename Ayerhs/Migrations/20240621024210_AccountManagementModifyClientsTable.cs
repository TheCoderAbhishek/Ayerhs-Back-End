using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayerhs.Migrations
{
    /// <inheritdoc />
    public partial class AccountManagementModifyClientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttemptCount",
                table: "tblclients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "tblclients",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateTime",
                table: "tblclients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockedUntil",
                table: "tblclients",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttemptCount",
                table: "tblclients");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "tblclients");

            migrationBuilder.DropColumn(
                name: "LastLoginDateTime",
                table: "tblclients");

            migrationBuilder.DropColumn(
                name: "LockedUntil",
                table: "tblclients");
        }
    }
}
