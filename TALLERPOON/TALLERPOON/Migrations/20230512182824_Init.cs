using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TALLERPOON.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "farmacia");

            migrationBuilder.CreateTable(
                name: "almacen",
                schema: "farmacia",
                columns: table => new
                {
                    Id_alm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_alm = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_almacen_Id_alm", x => x.Id_alm);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                schema: "farmacia",
                columns: table => new
                {
                    Id_prod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_prod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prec_prod = table.Column<int>(type: "int", nullable: false),
                    cant_prod = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_Id_prod", x => x.Id_prod);
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                schema: "farmacia",
                columns: table => new
                {
                    Id_prov = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_prov = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    tel_prov = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    corr_prov = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    dir_prov = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor_Id_prov", x => x.Id_prov);
                });

            migrationBuilder.CreateTable(
                name: "turno",
                columns: table => new
                {
                    id_turn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_turn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turno", x => x.id_turn);
                });

            migrationBuilder.CreateTable(
                name: "detalleap",
                schema: "farmacia",
                columns: table => new
                {
                    Id_detalleap = table.Column<int>(type: "int", nullable: false),
                    id_prod = table.Column<int>(type: "int", nullable: false),
                    Id_alm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleap_Id_detalleap", x => x.Id_detalleap);
                    table.ForeignKey(
                        name: "FK_detalleap_almacen",
                        column: x => x.Id_alm,
                        principalSchema: "farmacia",
                        principalTable: "almacen",
                        principalColumn: "Id_alm");
                    table.ForeignKey(
                        name: "FK_detalleap_productos",
                        column: x => x.Id_detalleap,
                        principalSchema: "farmacia",
                        principalTable: "productos",
                        principalColumn: "Id_prod");
                });

            migrationBuilder.CreateTable(
                name: "detallepp",
                schema: "farmacia",
                columns: table => new
                {
                    id_detallepp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_prod = table.Column<int>(type: "int", nullable: false),
                    nom_prod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cant_prod = table.Column<int>(type: "int", nullable: false),
                    id_prov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallepp_id_detallepp", x => x.id_detallepp);
                    table.ForeignKey(
                        name: "FK_detallepp_productos",
                        column: x => x.id_prod,
                        principalSchema: "farmacia",
                        principalTable: "productos",
                        principalColumn: "Id_prod");
                    table.ForeignKey(
                        name: "FK_detallepp_proveedor",
                        column: x => x.id_prov,
                        principalSchema: "farmacia",
                        principalTable: "proveedor",
                        principalColumn: "Id_prov");
                });

            migrationBuilder.CreateTable(
                name: "empleado",
                schema: "farmacia",
                columns: table => new
                {
                    Id_empl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_empl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    tel_emp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RFC_empl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    dir_empl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    turn_empl = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado_Id_empl", x => x.Id_empl);
                    table.ForeignKey(
                        name: "FK_empleado_turno",
                        column: x => x.turn_empl,
                        principalTable: "turno",
                        principalColumn: "id_turn");
                });

            migrationBuilder.CreateTable(
                name: "carrito",
                columns: table => new
                {
                    id_empl = table.Column<int>(type: "int", nullable: false),
                    id_prod = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrito", x => new { x.id_empl, x.id_prod });
                    table.ForeignKey(
                        name: "FK_carrito_empleado",
                        column: x => x.id_empl,
                        principalSchema: "farmacia",
                        principalTable: "empleado",
                        principalColumn: "Id_empl");
                    table.ForeignKey(
                        name: "FK_carrito_productos",
                        column: x => x.id_prod,
                        principalSchema: "farmacia",
                        principalTable: "productos",
                        principalColumn: "Id_prod");
                });

            migrationBuilder.CreateTable(
                name: "detalleea",
                schema: "farmacia",
                columns: table => new
                {
                    id_detalleEA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_empl = table.Column<int>(type: "int", nullable: false),
                    id_alm = table.Column<int>(type: "int", nullable: false),
                    fecha_detalleEA = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleea_id_detalleEA", x => x.id_detalleEA);
                    table.ForeignKey(
                        name: "FK_detalleea_almacen",
                        column: x => x.id_alm,
                        principalSchema: "farmacia",
                        principalTable: "almacen",
                        principalColumn: "Id_alm");
                    table.ForeignKey(
                        name: "FK_detalleea_empleado",
                        column: x => x.id_empl,
                        principalSchema: "farmacia",
                        principalTable: "empleado",
                        principalColumn: "Id_empl");
                });

            migrationBuilder.CreateTable(
                name: "detalleev",
                schema: "farmacia",
                columns: table => new
                {
                    Id_detalleEP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_empl = table.Column<int>(type: "int", nullable: false),
                    Id_prov = table.Column<int>(type: "int", nullable: false),
                    fech_detalleEP = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleev_Id_detalleEP", x => x.Id_detalleEP);
                    table.ForeignKey(
                        name: "FK_detalleev_empleado",
                        column: x => x.Id_empl,
                        principalSchema: "farmacia",
                        principalTable: "empleado",
                        principalColumn: "Id_empl");
                    table.ForeignKey(
                        name: "FK_detalleev_proveedor",
                        column: x => x.Id_prov,
                        principalSchema: "farmacia",
                        principalTable: "proveedor",
                        principalColumn: "Id_prov");
                });

            migrationBuilder.CreateTable(
                name: "venta",
                schema: "farmacia",
                columns: table => new
                {
                    Id_vent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fech_vent = table.Column<DateTime>(type: "date", nullable: false),
                    total_vent = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Id_empl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta_Id_vent", x => x.Id_vent);
                    table.ForeignKey(
                        name: "FK_venta_empleado",
                        column: x => x.Id_empl,
                        principalSchema: "farmacia",
                        principalTable: "empleado",
                        principalColumn: "Id_empl");
                });

            migrationBuilder.CreateIndex(
                name: "IX_carrito_id_prod",
                table: "carrito",
                column: "id_prod");

            migrationBuilder.CreateIndex(
                name: "IX_detalleap_Id_alm",
                schema: "farmacia",
                table: "detalleap",
                column: "Id_alm");

            migrationBuilder.CreateIndex(
                name: "IX_detalleea_id_alm",
                schema: "farmacia",
                table: "detalleea",
                column: "id_alm");

            migrationBuilder.CreateIndex(
                name: "IX_detalleea_id_empl",
                schema: "farmacia",
                table: "detalleea",
                column: "id_empl");

            migrationBuilder.CreateIndex(
                name: "IX_detalleev_Id_empl",
                schema: "farmacia",
                table: "detalleev",
                column: "Id_empl");

            migrationBuilder.CreateIndex(
                name: "IX_detalleev_Id_prov",
                schema: "farmacia",
                table: "detalleev",
                column: "Id_prov");

            migrationBuilder.CreateIndex(
                name: "IX_detallepp_id_prod",
                schema: "farmacia",
                table: "detallepp",
                column: "id_prod");

            migrationBuilder.CreateIndex(
                name: "IX_detallepp_id_prov",
                schema: "farmacia",
                table: "detallepp",
                column: "id_prov");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_turn_empl",
                schema: "farmacia",
                table: "empleado",
                column: "turn_empl");

            migrationBuilder.CreateIndex(
                name: "IX_venta_Id_empl",
                schema: "farmacia",
                table: "venta",
                column: "Id_empl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carrito");

            migrationBuilder.DropTable(
                name: "detalleap",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "detalleea",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "detalleev",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "detallepp",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "venta",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "almacen",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "productos",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "proveedor",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "empleado",
                schema: "farmacia");

            migrationBuilder.DropTable(
                name: "turno");
        }
    }
}
