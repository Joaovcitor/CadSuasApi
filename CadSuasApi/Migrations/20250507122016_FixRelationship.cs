using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadSuasApi.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FichaCadastralPessoal_Cpf",
                table: "FichaCadastralPessoal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FichaCadastralPessoal_Cpf",
                table: "FichaCadastralPessoal",
                column: "Cpf",
                unique: true);
        }
    }
}
