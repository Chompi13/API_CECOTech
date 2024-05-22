using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_registroTienda_RegistroTiendaid",
                table: "producto");

            migrationBuilder.DropIndex(
                name: "IX_producto_RegistroTiendaid",
                table: "producto");

            migrationBuilder.DropColumn(
                name: "RegistroTiendaid",
                table: "producto");

            migrationBuilder.AddColumn<string>(
                name: "productoID",
                table: "registroTienda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AlterColumn<int>(
                name: "carcelID",
                table: "preso",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productoID",
                table: "registroTienda");

            migrationBuilder.AddColumn<int>(
                name: "RegistroTiendaid",
                table: "producto",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "carcelID",
                table: "preso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
