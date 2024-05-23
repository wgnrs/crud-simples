using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace usuario.Migrations
{
    public partial class AtualizacaoUsuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "tb_usuario",
                newName: "nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "tb_usuario",
                newName: "NOME");
        }
    }
}
