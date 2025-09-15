using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEstabelecimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_tipo_estabelecimento_id",
                table: "Estabelecimentos");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_tipo_estabelecimento_id",
                table: "Estabelecimentos",
                column: "tipo_estabelecimento_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_tipo_estabelecimento_id",
                table: "Estabelecimentos");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_tipo_estabelecimento_id",
                table: "Estabelecimentos",
                column: "tipo_estabelecimento_id",
                unique: true);
        }
    }
}
