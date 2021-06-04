using Microsoft.EntityFrameworkCore.Migrations;

namespace CriadorCaes.Data.Migrations
{
    public partial class AdicaoRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c", "47b4a60f-8d82-4bb5-99c6-7362134de451", "Criador", "CRIADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "g", "d544b40f-3273-4191-b88d-9debcfc252e5", "Gestor", "GESTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g");
        }
    }
}
