using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class actualizacion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComprobanteImagenUrl",
                table: "PedidoCuota");

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "PedidoCuota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCuota_ImagenId",
                table: "PedidoCuota",
                column: "ImagenId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoCuota_Imagen_ImagenId",
                table: "PedidoCuota",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoCuota_Imagen_ImagenId",
                table: "PedidoCuota");

            migrationBuilder.DropIndex(
                name: "IX_PedidoCuota_ImagenId",
                table: "PedidoCuota");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "PedidoCuota");

            migrationBuilder.AddColumn<string>(
                name: "ComprobanteImagenUrl",
                table: "PedidoCuota",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
