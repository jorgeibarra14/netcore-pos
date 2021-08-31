using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos_backend.Migrations
{
    public partial class addCantidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "ProductosVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ProductosVentas");
        }
    }
}
