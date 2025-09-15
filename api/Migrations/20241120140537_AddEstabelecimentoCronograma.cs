using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddEstabelecimentoCronograma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstabelecimentoCronogramas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cronogramaid = table.Column<int>(type: "INTEGER", nullable: false),
                    estabelecimentoid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoCronogramas", x => x.id);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoCronogramas_Cronogramas_cronogramaid",
                        column: x => x.cronogramaid,
                        principalTable: "Cronogramas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoCronogramas_Estabelecimentos_estabelecimentoid",
                        column: x => x.estabelecimentoid,
                        principalTable: "Estabelecimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoCronogramas_cronogramaid",
                table: "EstabelecimentoCronogramas",
                column: "cronogramaid");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoCronogramas_estabelecimentoid",
                table: "EstabelecimentoCronogramas",
                column: "estabelecimentoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoCronogramas");
        }
    }
}
