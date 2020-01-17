using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWeb.Migrations
{
    public partial class Teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Filial_FilialId",
                table: "Vendedor");

            migrationBuilder.DropIndex(
                name: "IX_Vendedor_FilialId",
                table: "Vendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_FilialId",
                table: "Vendedor",
                column: "FilialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Filial_FilialId",
                table: "Vendedor",
                column: "FilialId",
                principalTable: "Filial",
                principalColumn: "FilialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
