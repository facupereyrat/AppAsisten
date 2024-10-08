using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAsisten.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuotas_Miembros_MiembroId",
                table: "Cuotas");

            migrationBuilder.RenameColumn(
                name: "CodigoQR",
                table: "Miembros",
                newName: "Codigo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Miembros",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Administradores",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuotas_Miembros_MiembroId",
                table: "Cuotas",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Cuotas_Miembros_MiembroId",
                table: "Cuotas");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Miembros",
                newName: "CodigoQR");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Miembros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Administradores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Miembros_MiembroId",
                table: "Asistencias",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuotas_Miembros_MiembroId",
                table: "Cuotas",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
