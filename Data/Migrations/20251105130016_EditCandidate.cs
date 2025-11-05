using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class EditCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_UsersAuth_CandidateId",
                table: "Candidates");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Candidates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_UserId",
                table: "Candidates",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_UsersAuth_UserId",
                table: "Candidates",
                column: "UserId",
                principalTable: "UsersAuth",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_UsersAuth_UserId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_UserId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Candidates");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_UsersAuth_CandidateId",
                table: "Candidates",
                column: "CandidateId",
                principalTable: "UsersAuth",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
