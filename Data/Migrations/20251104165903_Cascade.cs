using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAuth_Candidates_UserId",
                table: "UsersAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_UsersAuth_CandidateId",
                table: "Candidates",
                column: "CandidateId",
                principalTable: "UsersAuth",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData",
                column: "UserId",
                principalTable: "UsersAuth",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_UsersAuth_CandidateId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAuth_Candidates_UserId",
                table: "UsersAuth",
                column: "UserId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_UsersAuth_UserId",
                table: "UsersData",
                column: "UserId",
                principalTable: "UsersAuth",
                principalColumn: "UserId");
        }
    }
}
