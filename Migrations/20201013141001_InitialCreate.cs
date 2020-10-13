using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2Hotel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(45)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(45)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(type: "int(11)", nullable: false),
                    Capacidad = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(45)", nullable: false),
                    Password = table.Column<string>(type: "varchar(45)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: false),
                    Apelllido = table.Column<string>(type: "varchar(45)", nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(45)", nullable: true),
                    Role = table.Column<string>(type: "varchar(45)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationId = table.Column<int>(type: "int(11)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HabitacionId = table.Column<int>(type: "int(11)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(45)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int(11)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "Creator",
                        column: x => x.CreationId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Habitacion",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "User",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Numero_UNIQUE",
                table: "Habitacion",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Creator_idx",
                table: "Reserva",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "Habitacion_idx",
                table: "Reserva",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "User_idx",
                table: "Reserva",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "Username_UNIQUE",
                table: "Usuario",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Habitacion");
        }
    }
}
