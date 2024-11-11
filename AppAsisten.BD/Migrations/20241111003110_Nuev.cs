using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAsisten.BD.Migrations
{
    /// <inheritdoc />
    public partial class Nuev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Miembros");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Miembros");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Miembros");

            migrationBuilder.RenameColumn(
                name: "EsActivo",
                table: "Miembros",
                newName: "EstaActivo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Miembros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "CodigoQR",
                table: "Miembros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Entrada",
                table: "Asistencias",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CodigoQR",
                table: "Asistencias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "CodigoQR",
                table: "Miembros");

            migrationBuilder.DropColumn(
                name: "CodigoQR",
                table: "Asistencias");

            migrationBuilder.RenameColumn(
                name: "EstaActivo",
                table: "Miembros",
                newName: "EsActivo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Miembros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Entrada",
                table: "Asistencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
