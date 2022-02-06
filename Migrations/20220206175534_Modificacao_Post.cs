using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaCronosAPI.Migrations
{
    public partial class Modificacao_Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Usuario_CriadorId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_CriadorId",
                table: "Post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_CriadorId",
                table: "Post",
                column: "CriadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Usuario_CriadorId",
                table: "Post",
                column: "CriadorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
