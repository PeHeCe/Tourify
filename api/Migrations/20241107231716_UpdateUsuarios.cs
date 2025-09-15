using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome_usuario",
                table: "Usuarios",
                newName: "telefone");

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sobrenome",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cep",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "sobrenome",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Usuarios",
                newName: "nome_usuario");
        }
    }
}
