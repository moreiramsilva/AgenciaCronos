using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaCronosAPI.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntegrantesEquipe_Servicos_ServicosId",
                table: "IntegrantesEquipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_IntegrantesEquipe_IntegrantesEquipeId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IntegrantesEquipeId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_IntegrantesEquipe_ServicosId",
                table: "IntegrantesEquipe");

            migrationBuilder.DropColumn(
                name: "IntegrantesEquipeId",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IntegrantesEquipeId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IntegrantesEquipeId",
                table: "Usuario",
                column: "IntegrantesEquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrantesEquipe_ServicosId",
                table: "IntegrantesEquipe",
                column: "ServicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntegrantesEquipe_Servicos_ServicosId",
                table: "IntegrantesEquipe",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_IntegrantesEquipe_IntegrantesEquipeId",
                table: "Usuario",
                column: "IntegrantesEquipeId",
                principalTable: "IntegrantesEquipe",
                principalColumn: "Id");
        }
    }
}
