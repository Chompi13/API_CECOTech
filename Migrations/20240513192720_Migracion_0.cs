using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carcel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carcel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<double>(type: "float", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "guardia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experiencia = table.Column<int>(type: "int", nullable: false),
                    nplaca = table.Column<int>(type: "int", nullable: false),
                    sancionador = table.Column<bool>(type: "bit", nullable: false),
                    carcelid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guardia", x => x.id);
                    table.ForeignKey(
                        name: "FK_guardia_carcel_carcelid",
                        column: x => x.carcelid,
                        principalTable: "carcel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modulo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    actividades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pago = table.Column<double>(type: "float", nullable: false),
                    carcelid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo", x => x.id);
                    table.ForeignKey(
                        name: "FK_modulo_carcel_carcelid",
                        column: x => x.carcelid,
                        principalTable: "carcel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tienda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rangoMinimo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tamano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carcelid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tienda", x => x.id);
                    table.ForeignKey(
                        name: "FK_tienda_carcel_carcelid",
                        column: x => x.carcelid,
                        principalTable: "carcel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "preso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ahorros = table.Column<double>(type: "float", nullable: false),
                    moduloid = table.Column<int>(type: "int", nullable: false),
                    comportamiento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preso", x => x.id);
                    table.ForeignKey(
                        name: "FK_preso_modulo_moduloid",
                        column: x => x.moduloid,
                        principalTable: "modulo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sancion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    razon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    presoid = table.Column<int>(type: "int", nullable: false),
                    nplaca_guardia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sancion", x => x.id);
                    table.ForeignKey(
                        name: "FK_sancion_preso_presoid",
                        column: x => x.presoid,
                        principalTable: "preso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_guardia_carcelid",
                table: "guardia",
                column: "carcelid");

            migrationBuilder.CreateIndex(
                name: "IX_guardia_nplaca",
                table: "guardia",
                column: "nplaca",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_modulo_carcelid",
                table: "modulo",
                column: "carcelid");

            migrationBuilder.CreateIndex(
                name: "IX_preso_moduloid",
                table: "preso",
                column: "moduloid");

            migrationBuilder.CreateIndex(
                name: "IX_sancion_presoid",
                table: "sancion",
                column: "presoid");

            migrationBuilder.CreateIndex(
                name: "IX_tienda_carcelid",
                table: "tienda",
                column: "carcelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guardia");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "sancion");

            migrationBuilder.DropTable(
                name: "tienda");

            migrationBuilder.DropTable(
                name: "preso");

            migrationBuilder.DropTable(
                name: "modulo");

            migrationBuilder.DropTable(
                name: "carcel");
        }
    }
}
