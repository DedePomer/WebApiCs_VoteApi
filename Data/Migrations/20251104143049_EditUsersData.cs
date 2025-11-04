using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class EditUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UsersData",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData",
                column: "UserId",
                principalTable: "UsersAuth",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UsersData",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData",
                column: "UserId",
                principalTable: "UsersAuth",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
