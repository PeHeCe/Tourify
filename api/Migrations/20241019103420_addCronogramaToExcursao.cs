using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class addCronogramaToExcursao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursoes_Empresas_Empresaid",
                table: "Excursoes");

            migrationBuilder.RenameColumn(
                name: "Empresaid",
                table: "Excursoes",
                newName: "empresaid");

            migrationBuilder.RenameIndex(
                name: "IX_Excursoes_Empresaid",
                table: "Excursoes",
                newName: "IX_Excursoes_empresaid");

            migrationBuilder.AddColumn<int>(
                name: "cronogramaid",
                table: "Excursoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Excursoes_cronogramaid",
                table: "Excursoes",
                column: "cronogramaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Excursoes_Cronogramas_cronogramaid",
                table: "Excursoes",
                column: "cronogramaid",
                principalTable: "Cronogramas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Excursoes_Empresas_empresaid",
                table: "Excursoes",
                column: "empresaid",
                principalTable: "Empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursoes_Cronogramas_cronogramaid",
                table: "Excursoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Excursoes_Empresas_empresaid",
                table: "Excursoes");

            migrationBuilder.DropIndex(
                name: "IX_Excursoes_cronogramaid",
                table: "Excursoes");

            migrationBuilder.DropColumn(
                name: "cronogramaid",
                table: "Excursoes");

            migrationBuilder.RenameColumn(
                name: "empresaid",
                table: "Excursoes",
                newName: "Empresaid");

            migrationBuilder.RenameIndex(
                name: "IX_Excursoes_empresaid",
                table: "Excursoes",
                newName: "IX_Excursoes_Empresaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Excursoes_Empresas_Empresaid",
                table: "Excursoes",
                column: "Empresaid",
                principalTable: "Empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
