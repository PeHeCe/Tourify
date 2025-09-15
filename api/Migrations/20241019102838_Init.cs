using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cronogramas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    custo_maximo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    data = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    hora_inicio = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    hora_fim = table.Column<TimeOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronogramas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    cnpj = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEstabelecimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEstabelecimentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome_usuario = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Excursoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    local_partida = table.Column<string>(type: "TEXT", nullable: false),
                    local__destino = table.Column<string>(type: "TEXT", nullable: false),
                    data = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Empresaid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Excursoes_Empresas_Empresaid",
                        column: x => x.Empresaid,
                        principalTable: "Empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: false),
                    cnpj = table.Column<string>(type: "TEXT", nullable: false),
                    telefone_contato = table.Column<string>(type: "TEXT", nullable: false),
                    horario_abertura = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    horario_fechamento = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    nivel_preco = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    site = table.Column<string>(type: "TEXT", nullable: false),
                    tipo_estabelecimento_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_TiposEstabelecimentos_tipo_estabelecimento_id",
                        column: x => x.tipo_estabelecimento_id,
                        principalTable: "TiposEstabelecimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritosCronogramas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    apelido = table.Column<string>(type: "TEXT", nullable: false),
                    cronogramaid = table.Column<int>(type: "INTEGER", nullable: false),
                    usuarioid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritosCronogramas", x => x.id);
                    table.ForeignKey(
                        name: "FK_FavoritosCronogramas_Cronogramas_cronogramaid",
                        column: x => x.cronogramaid,
                        principalTable: "Cronogramas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritosCronogramas_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosCronogramas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    papel = table.Column<string>(type: "TEXT", nullable: false),
                    usuarioid = table.Column<int>(type: "INTEGER", nullable: false),
                    Cronogramaid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCronogramas", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsuariosCronogramas_Cronogramas_Cronogramaid",
                        column: x => x.Cronogramaid,
                        principalTable: "Cronogramas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UsuariosCronogramas_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritosExcursoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    apelido = table.Column<string>(type: "TEXT", nullable: false),
                    excursaoid = table.Column<int>(type: "INTEGER", nullable: false),
                    usuarioid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritosExcursoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_FavoritosExcursoes_Excursoes_excursaoid",
                        column: x => x.excursaoid,
                        principalTable: "Excursoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritosExcursoes_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nota = table.Column<int>(type: "INTEGER", nullable: false),
                    mensagem = table.Column<string>(type: "TEXT", nullable: false),
                    usuarioid = table.Column<int>(type: "INTEGER", nullable: false),
                    estabelecimentoid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Estabelecimentos_estabelecimentoid",
                        column: x => x.estabelecimentoid,
                        principalTable: "Estabelecimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritosEstabelecimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    apelido = table.Column<string>(type: "TEXT", nullable: false),
                    estabelecimentoid = table.Column<int>(type: "INTEGER", nullable: false),
                    usuarioid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritosEstabelecimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_FavoritosEstabelecimentos_Estabelecimentos_estabelecimentoid",
                        column: x => x.estabelecimentoid,
                        principalTable: "Estabelecimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritosEstabelecimentos_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_estabelecimentoid",
                table: "Avaliacoes",
                column: "estabelecimentoid");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_usuarioid",
                table: "Avaliacoes",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_tipo_estabelecimento_id",
                table: "Estabelecimentos",
                column: "tipo_estabelecimento_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Excursoes_Empresaid",
                table: "Excursoes",
                column: "Empresaid");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritosCronogramas_cronogramaid",
                table: "FavoritosCronogramas",
                column: "cronogramaid");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritosCronogramas_usuarioid",
                table: "FavoritosCronogramas",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritosEstabelecimentos_estabelecimentoid",
                table: "FavoritosEstabelecimentos",
                column: "estabelecimentoid");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritosEstabelecimentos_usuarioid",
                table: "FavoritosEstabelecimentos",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritosExcursoes_excursaoid",
                table: "FavoritosExcursoes",
                column: "excursaoid");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritosExcursoes_usuarioid",
                table: "FavoritosExcursoes",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCronogramas_Cronogramaid",
                table: "UsuariosCronogramas",
                column: "Cronogramaid");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCronogramas_usuarioid",
                table: "UsuariosCronogramas",
                column: "usuarioid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "FavoritosCronogramas");

            migrationBuilder.DropTable(
                name: "FavoritosEstabelecimentos");

            migrationBuilder.DropTable(
                name: "FavoritosExcursoes");

            migrationBuilder.DropTable(
                name: "UsuariosCronogramas");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Excursoes");

            migrationBuilder.DropTable(
                name: "Cronogramas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposEstabelecimentos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
