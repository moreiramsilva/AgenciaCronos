using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaCronosAPI.Migrations
{
    public partial class Modificacao_Integrante_Equipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicosId",
                table: "IntegrantesEquipe",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntegrantesEquipe_Servicos_ServicosId",
                table: "IntegrantesEquipe");

            migrationBuilder.DropIndex(
                name: "IX_IntegrantesEquipe_ServicosId",
                table: "IntegrantesEquipe");

            migrationBuilder.DropColumn(
                name: "ServicosId",
                table: "IntegrantesEquipe");
        }
    }
}
