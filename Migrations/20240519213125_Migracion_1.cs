using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guardia_carcel_carcelid",
                table: "guardia");

            migrationBuilder.DropForeignKey(
                name: "FK_modulo_carcel_carcelid",
                table: "modulo");

            migrationBuilder.DropForeignKey(
                name: "FK_preso_modulo_moduloid",
                table: "preso");

            migrationBuilder.DropForeignKey(
                name: "FK_sancion_preso_presoid",
                table: "sancion");

            migrationBuilder.DropForeignKey(
                name: "FK_tienda_carcel_carcelid",
                table: "tienda");

            migrationBuilder.DropIndex(
                name: "IX_tienda_carcelid",
                table: "tienda");

            migrationBuilder.DropIndex(
                name: "IX_sancion_presoid",
                table: "sancion");

            migrationBuilder.DropIndex(
                name: "IX_preso_moduloid",
                table: "preso");

            migrationBuilder.DropIndex(
                name: "IX_modulo_carcelid",
                table: "modulo");

            migrationBuilder.DropIndex(
                name: "IX_guardia_carcelid",
                table: "guardia");

            migrationBuilder.RenameColumn(
                name: "carcelid",
                table: "tienda",
                newName: "carcelID");

            migrationBuilder.RenameColumn(
                name: "presoid",
                table: "sancion",
                newName: "presoID");

            migrationBuilder.RenameColumn(
                name: "moduloid",
                table: "preso",
                newName: "moduloID");

            migrationBuilder.RenameColumn(
                name: "carcelid",
                table: "modulo",
                newName: "carcelID");

            migrationBuilder.RenameColumn(
                name: "carcelid",
                table: "guardia",
                newName: "carcelID");

            migrationBuilder.AddColumn<int>(
                name: "RegistroTiendaid",
                table: "producto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "registroTienda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coste = table.Column<int>(type: "int", nullable: false),
                    presoId = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tiendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registroTienda", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_producto_RegistroTiendaid",
                table: "producto",
                column: "RegistroTiendaid");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_registroTienda_RegistroTiendaid",
                table: "producto",
                column: "RegistroTiendaid",
                principalTable: "registroTienda",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_registroTienda_RegistroTiendaid",
                table: "producto");

            migrationBuilder.DropTable(
                name: "registroTienda");

            migrationBuilder.DropIndex(
                name: "IX_producto_RegistroTiendaid",
                table: "producto");

            migrationBuilder.DropColumn(
                name: "RegistroTiendaid",
                table: "producto");

            migrationBuilder.RenameColumn(
                name: "carcelID",
                table: "tienda",
                newName: "carcelid");

            migrationBuilder.RenameColumn(
                name: "presoID",
                table: "sancion",
                newName: "presoid");

            migrationBuilder.RenameColumn(
                name: "moduloID",
                table: "preso",
                newName: "moduloid");

            migrationBuilder.RenameColumn(
                name: "carcelID",
                table: "modulo",
                newName: "carcelid");

            migrationBuilder.RenameColumn(
                name: "carcelID",
                table: "guardia",
                newName: "carcelid");

            migrationBuilder.CreateIndex(
                name: "IX_tienda_carcelid",
                table: "tienda",
                column: "carcelid");

            migrationBuilder.CreateIndex(
                name: "IX_sancion_presoid",
                table: "sancion",
                column: "presoid");

            migrationBuilder.CreateIndex(
                name: "IX_preso_moduloid",
                table: "preso",
                column: "moduloid");

            migrationBuilder.CreateIndex(
                name: "IX_modulo_carcelid",
                table: "modulo",
                column: "carcelid");

            migrationBuilder.CreateIndex(
                name: "IX_guardia_carcelid",
                table: "guardia",
                column: "carcelid");

            migrationBuilder.AddForeignKey(
                name: "FK_guardia_carcel_carcelid",
                table: "guardia",
                column: "carcelid",
                principalTable: "carcel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modulo_carcel_carcelid",
                table: "modulo",
                column: "carcelid",
                principalTable: "carcel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_preso_modulo_moduloid",
                table: "preso",
                column: "moduloid",
                principalTable: "modulo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sancion_preso_presoid",
                table: "sancion",
                column: "presoid",
                principalTable: "preso",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tienda_carcel_carcelid",
                table: "tienda",
                column: "carcelid",
                principalTable: "carcel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
