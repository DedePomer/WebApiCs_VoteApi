using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class OpiatEditEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAuth_UsersData_UserId",
                table: "UsersAuth");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData");

            migrationBuilder.DropIndex(
                name: "IX_UsersData_UserId",
                table: "UsersData");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAuth_UsersData_UserId",
                table: "UsersAuth",
                column: "UserId",
                principalTable: "UsersData",
                principalColumn: "DataId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
