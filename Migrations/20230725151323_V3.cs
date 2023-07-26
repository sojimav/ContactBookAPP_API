using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactBookAPP.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<int>_AspNetUsers_UserContactId",
                table: "IdentityUserRole<int>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<int>_Roles_RoleId",
                table: "IdentityUserRole<int>");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserRole<int>",
                table: "IdentityUserRole<int>");

            migrationBuilder.RenameColumn(
                name: "UserContactId",
                table: "IdentityUserRole<int>",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserRole<int>_UserContactId",
                table: "IdentityUserRole<int>",
                newName: "IX_IdentityUserRole<int>_RolesId");

            migrationBuilder.AddColumn<string>(
                name: "PersonsId",
                table: "IdentityUserRole<int>",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAssignable",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserRole<int>",
                table: "IdentityUserRole<int>",
                columns: new[] { "PersonsId", "RolesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_AspNetRoles_RolesId",
                table: "IdentityUserRole<int>",
                column: "RolesId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_AspNetUsers_PersonsId",
                table: "IdentityUserRole<int>",
                column: "PersonsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<int>_AspNetRoles_RolesId",
                table: "IdentityUserRole<int>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<int>_AspNetUsers_PersonsId",
                table: "IdentityUserRole<int>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserRole<int>",
                table: "IdentityUserRole<int>");

            migrationBuilder.DropColumn(
                name: "PersonsId",
                table: "IdentityUserRole<int>");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsAssignable",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "IdentityUserRole<int>",
                newName: "UserContactId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserRole<int>_RolesId",
                table: "IdentityUserRole<int>",
                newName: "IX_IdentityUserRole<int>_UserContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserRole<int>",
                table: "IdentityUserRole<int>",
                columns: new[] { "RoleId", "UserContactId" });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_AspNetUsers_UserContactId",
                table: "IdentityUserRole<int>",
                column: "UserContactId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_Roles_RoleId",
                table: "IdentityUserRole<int>",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
