using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class actualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Tela_TematicaId",
                table: "PedidoDetalle");

            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "PersonaRol");

            migrationBuilder.DropTable(
                name: "UsuarioAccesoEnpoint");

            migrationBuilder.DropColumn(
                name: "RutaImagen",
                table: "Tela");

            migrationBuilder.DropColumn(
                name: "RutaImagen",
                table: "ProductoFoto");

            migrationBuilder.DropColumn(
                name: "RutaLogo",
                table: "Compania");

            migrationBuilder.DropColumn(
                name: "RutaImagen",
                table: "Color");

            migrationBuilder.RenameColumn(
                name: "TematicaId",
                table: "PedidoDetalle",
                newName: "TelaId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalle_TematicaId",
                table: "PedidoDetalle",
                newName: "IX_PedidoDetalle_TelaId");

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "Tela",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RutaImagen",
                table: "RepartidorVehiculo",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "RepartidorVehiculo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "ProductoFoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImagenLogoId",
                table: "Compania",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "Color",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuditoriaEntidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTabla = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LlaveValores = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ValoresAntiguos = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ValoresNuevos = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaEntidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteDireccionEnvioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UbigeoId = table.Column<int>(type: "int", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepartidorVehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    Subtotal = table.Column<decimal>(type: "money", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "money", nullable: false),
                    PrecioEnvio = table.Column<decimal>(type: "money", nullable: false),
                    EsPedidoPagado = table.Column<bool>(type: "bit", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizacion_ClienteDireccionEnvio_ClienteDireccionEnvioId",
                        column: x => x.ClienteDireccionEnvioId,
                        principalTable: "ClienteDireccionEnvio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizacion_RepartidorVehiculo_RepartidorVehiculoId",
                        column: x => x.RepartidorVehiculoId,
                        principalTable: "RepartidorVehiculo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cotizacion_Ubigeo_UbigeoId",
                        column: x => x.UbigeoId,
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelaId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    NombreBordado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "money", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "money", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "money", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    EsAdicional = table.Column<bool>(type: "bit", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CotizacionDetalle_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CotizacionDetalle_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotizacionDetalle_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotizacionDetalle_Tela_TelaId",
                        column: x => x.TelaId,
                        principalTable: "Tela",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Endpoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Entidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreControlador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreAccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagen_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEnpointBloqueado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndpointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEnpointBloqueado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEnpointBloqueado_Endpoint_EndpointId",
                        column: x => x.EndpointId,
                        principalTable: "Endpoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioEnpointBloqueado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tela_ImagenId",
                table: "Tela",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_RepartidorVehiculo_ImagenId",
                table: "RepartidorVehiculo",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFoto_ImagenId",
                table: "ProductoFoto",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ImagenId",
                table: "Color",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_ClienteDireccionEnvioId",
                table: "Cotizacion",
                column: "ClienteDireccionEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_ClienteId",
                table: "Cotizacion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_EstadoId",
                table: "Cotizacion",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_RepartidorVehiculoId",
                table: "Cotizacion",
                column: "RepartidorVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_UbigeoId",
                table: "Cotizacion",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetalle_ColorId",
                table: "CotizacionDetalle",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetalle_PedidoId",
                table: "CotizacionDetalle",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetalle_ProductoId",
                table: "CotizacionDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetalle_TelaId",
                table: "CotizacionDetalle",
                column: "TelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagen_CompaniaId",
                table: "Imagen",
                column: "CompaniaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEnpointBloqueado_EndpointId",
                table: "UsuarioEnpointBloqueado",
                column: "EndpointId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEnpointBloqueado_UsuarioId",
                table: "UsuarioEnpointBloqueado",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Imagen_ImagenId",
                table: "Color",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalle_Tela_TelaId",
                table: "PedidoDetalle",
                column: "TelaId",
                principalTable: "Tela",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoFoto_Imagen_ImagenId",
                table: "ProductoFoto",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepartidorVehiculo_Imagen_ImagenId",
                table: "RepartidorVehiculo",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tela_Imagen_ImagenId",
                table: "Tela",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Imagen_ImagenId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Tela_TelaId",
                table: "PedidoDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoFoto_Imagen_ImagenId",
                table: "ProductoFoto");

            migrationBuilder.DropForeignKey(
                name: "FK_RepartidorVehiculo_Imagen_ImagenId",
                table: "RepartidorVehiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tela_Imagen_ImagenId",
                table: "Tela");

            migrationBuilder.DropTable(
                name: "AuditoriaEntidad");

            migrationBuilder.DropTable(
                name: "Cotizacion");

            migrationBuilder.DropTable(
                name: "CotizacionDetalle");

            migrationBuilder.DropTable(
                name: "Imagen");

            migrationBuilder.DropTable(
                name: "UsuarioEnpointBloqueado");

            migrationBuilder.DropTable(
                name: "Endpoint");

            migrationBuilder.DropIndex(
                name: "IX_Tela_ImagenId",
                table: "Tela");

            migrationBuilder.DropIndex(
                name: "IX_RepartidorVehiculo_ImagenId",
                table: "RepartidorVehiculo");

            migrationBuilder.DropIndex(
                name: "IX_ProductoFoto_ImagenId",
                table: "ProductoFoto");

            migrationBuilder.DropIndex(
                name: "IX_Color_ImagenId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "Tela");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "RepartidorVehiculo");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "ProductoFoto");

            migrationBuilder.DropColumn(
                name: "ImagenLogoId",
                table: "Compania");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "Color");

            migrationBuilder.RenameColumn(
                name: "TelaId",
                table: "PedidoDetalle",
                newName: "TematicaId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalle_TelaId",
                table: "PedidoDetalle",
                newName: "IX_PedidoDetalle_TematicaId");

            migrationBuilder.AddColumn<string>(
                name: "RutaImagen",
                table: "Tela",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RutaImagen",
                table: "RepartidorVehiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RutaImagen",
                table: "ProductoFoto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RutaLogo",
                table: "Compania",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RutaImagen",
                table: "Color",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LlaveValores = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    NombreTabla = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ValoresAntiguos = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ValoresNuevos = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAccesoEnpoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RutaEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAccesoEnpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioAccesoEnpoint_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAccesoEnpoint_UsuarioId",
                table: "UsuarioAccesoEnpoint",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalle_Tela_TematicaId",
                table: "PedidoDetalle",
                column: "TematicaId",
                principalTable: "Tela",
                principalColumn: "Id");
        }
    }
}
