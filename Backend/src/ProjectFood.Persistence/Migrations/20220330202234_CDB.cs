using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectFood.Persistence.Migrations
{
    public partial class CDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Functions_AspNetUsers_UserId",
                table: "Functions");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_UserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Functions_UserId",
                table: "Functions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Functions");

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Function",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Titles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Functions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_UserId",
                table: "Titles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Functions_UserId",
                table: "Functions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Functions_AspNetUsers_UserId",
                table: "Functions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
