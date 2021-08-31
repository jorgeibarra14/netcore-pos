using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos_backend.Migrations
{
    public partial class changeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosVentas_Productos_ProductoId",
                table: "ProductosVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosVentas_Ventas_VentaId",
                table: "ProductosVentas");

            migrationBuilder.DropIndex(
                name: "IX_ProductosVentas_ProductoId",
                table: "ProductosVentas");

            migrationBuilder.DropIndex(
                name: "IX_ProductosVentas_VentaId",
                table: "ProductosVentas");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "ProductosVentas");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "ProductosVentas");

            migrationBuilder.AddColumn<int>(
                name: "Producto",
                table: "ProductosVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Venta",
                table: "ProductosVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producto",
                table: "ProductosVentas");

            migrationBuilder.DropColumn(
                name: "Venta",
                table: "ProductosVentas");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "ProductosVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "ProductosVentas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVentas_ProductoId",
                table: "ProductosVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVentas_VentaId",
                table: "ProductosVentas",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosVentas_Productos_ProductoId",
                table: "ProductosVentas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosVentas_Ventas_VentaId",
                table: "ProductosVentas",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
