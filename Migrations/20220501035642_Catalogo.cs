using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVen.Migrations
{
    public partial class Catalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Talla",
                table: "t_catalogo",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Talla",
                table: "t_catalogo");
        }
    }
}
