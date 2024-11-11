using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAsisten.BD.Migrations
{
    /// <inheritdoc />
    public partial class correccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Administradores_AdministradorId",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Miembros_Administradores_AdministradorId",
                table: "Miembros");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropIndex(
                name: "IX_Miembros_AdministradorId",
                table: "Miembros");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_AdministradorId",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Miembros");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Asistencias");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Miembros",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Miembros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Miembros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Miembros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Asistencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiembroId = table.Column<int>(type: "int", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: true),
                    EsPagada = table.Column<bool>(type: "bit", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuotas_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuotas_Miembros_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_AdministradorId",
                table: "Miembros",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_AdministradorId",
                table: "Asistencias",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_AdministradorId",
                table: "Cuotas",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_MiembroId",
                table: "Cuotas",
                column: "MiembroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Administradores_AdministradorId",
                table: "Asistencias",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Miembros_Administradores_AdministradorId",
                table: "Miembros",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id");
        }
    }
}
