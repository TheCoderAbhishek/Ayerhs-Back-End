using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ayerhs.Migrations
{
    /// <inheritdoc />
    public partial class AccountManagementCreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblclients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    ClientName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ClientUsername = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ClientEmail = table.Column<string>(type: "text", nullable: false),
                    ClientPassword = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    ClientMobileNumber = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    DeletedState = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutoDeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Salt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblclients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblroles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblroles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblclient_roles",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblclient_roles", x => new { x.ClientId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tblclient_roles_tblclients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblclients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblclient_roles_tblroles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblroles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblroles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Super Admin -> Role Full control over the system.", "SuperAdmin" },
                    { 2, "Admin Role -> Manage users, roles, and some system settings.", "Admin" },
                    { 3, "User Role -> Can access and modify their own data.", "User" },
                    { 4, "Viewer Role -> Limited access to view specific data.", "Viewer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblclient_roles_RoleId",
                table: "tblclient_roles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblclient_roles");

            migrationBuilder.DropTable(
                name: "tblclients");

            migrationBuilder.DropTable(
                name: "tblroles");
        }
    }
}
