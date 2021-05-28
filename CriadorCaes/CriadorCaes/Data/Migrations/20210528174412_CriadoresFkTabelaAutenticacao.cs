using Microsoft.EntityFrameworkCore.Migrations;

namespace CriadorCaes.Data.Migrations
{
    public partial class CriadoresFkTabelaAutenticacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNameId",
                table: "Criadores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "Criadores");
        }
    }
}
