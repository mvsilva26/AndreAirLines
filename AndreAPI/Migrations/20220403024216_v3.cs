using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAPI.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Endereco",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Endereco",
                newName: "Localidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Endereco",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Endereco",
                newName: "Cidade");
        }
    }
}
