using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAsisten.BD.Migrations
{
    /// <inheritdoc />
    public partial class Actualizo4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Miembros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Cuotas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Asistencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Miembros_AdministradorId",
                table: "Miembros",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_AdministradorId",
                table: "Cuotas",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_AdministradorId",
                table: "Asistencias",
                column: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Administradores_AdministradorId",
                table: "Asistencias",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuotas_Administradores_AdministradorId",
                table: "Cuotas",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembros_Administradores_AdministradorId",
                table: "Miembros",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Administradores_AdministradorId",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuotas_Administradores_AdministradorId",
                table: "Cuotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Miembros_Administradores_AdministradorId",
                table: "Miembros");

            migrationBuilder.DropIndex(
                name: "IX_Miembros_AdministradorId",
                table: "Miembros");

            migrationBuilder.DropIndex(
                name: "IX_Cuotas_AdministradorId",
                table: "Cuotas");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_AdministradorId",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Miembros");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Cuotas");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Asistencias");
        }
    }
}
