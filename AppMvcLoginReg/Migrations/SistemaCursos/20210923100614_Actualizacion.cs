using Microsoft.EntityFrameworkCore.Migrations;

namespace AppMvcLoginReg.Migrations.SistemaCursos
{
    public partial class Actualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Curso_CursoAsignadoIdCurso",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_CursoAsignadoIdCurso",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "CursoAsignadoIdCurso",
                table: "Alumno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoAsignadoIdCurso",
                table: "Alumno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_CursoAsignadoIdCurso",
                table: "Alumno",
                column: "CursoAsignadoIdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Curso_CursoAsignadoIdCurso",
                table: "Alumno",
                column: "CursoAsignadoIdCurso",
                principalTable: "Curso",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
