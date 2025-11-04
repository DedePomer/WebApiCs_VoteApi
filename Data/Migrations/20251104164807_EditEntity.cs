using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class EditEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData");

            migrationBuilder.DropIndex(
                name: "IX_UsersData_UserId",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "DataId",
                table: "UsersAuth");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAuth_UsersData_UserId",
                table: "UsersAuth",
                column: "UserId",
                principalTable: "UsersData",
                principalColumn: "DataId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAuth_UsersData_UserId",
                table: "UsersAuth");

            migrationBuilder.AddColumn<Guid>(
                name: "DataId",
                table: "UsersAuth",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersData_UserId",
                table: "UsersData",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData",
                column: "UserId",
                principalTable: "UsersAuth",
                principalColumn: "UserId");
        }
    }
}
