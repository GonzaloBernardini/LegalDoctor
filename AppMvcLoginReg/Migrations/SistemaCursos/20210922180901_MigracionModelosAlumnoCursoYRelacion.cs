using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppMvcLoginReg.Migrations.SistemaCursos
{
    public partial class MigracionModelosAlumnoCursoYRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreCurso",
                table: "Curso",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinalizacionCurso",
                table: "Curso",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioCurso",
                table: "Curso",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumeroDeClases",
                table: "Curso",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ValorCursos",
                table: "Curso",
                type: "real",
                unicode: false,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    IdAlumno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Nota1 = table.Column<float>(type: "real", nullable: true),
                    Nota2 = table.Column<float>(type: "real", nullable: true),
                    PromedioFinal = table.Column<float>(type: "real", nullable: true),
                    CursoAsignadoIdCurso = table.Column<int>(type: "int", nullable: true),
                    Inasistencias = table.Column<int>(type: "int", nullable: true),
                    Seguimiento = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.IdAlumno);
                    table.ForeignKey(
                        name: "FK_Alumno_Curso_CursoAsignadoIdCurso",
                        column: x => x.CursoAsignadoIdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoCurso",
                columns: table => new
                {
                    IdAlumno = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoCurso", x => new { x.IdAlumno, x.IdCurso });
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Alumno_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumno",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_CursoAsignadoIdCurso",
                table: "Alumno",
                column: "CursoAsignadoIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_IdCurso",
                table: "AlumnoCurso",
                column: "IdCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoCurso");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropColumn(
                name: "FechaFinalizacionCurso",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "FechaInicioCurso",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "NumeroDeClases",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "ValorCursos",
                table: "Curso");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCurso",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);
        }
    }
}
