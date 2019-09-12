using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WepAppCursos.Data.Migrations
{
    public partial class clasesModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Especialidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Creditos = table.Column<byte>(nullable: false),
                    Horas = table.Column<byte>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    CategoriaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoID);
                    table.ForeignKey(
                        name: "FK_Curso_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignacion",
                columns: table => new
                {
                    AsignacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursoID = table.Column<int>(nullable: false),
                    IntructorID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    InstructorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacion", x => x.AsignacionID);
                    table.ForeignKey(
                        name: "FK_Asignacion_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignacion_Persona_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    InscripcionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grado = table.Column<int>(nullable: false),
                    Curso = table.Column<int>(nullable: false),
                    EstudianteID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Pago = table.Column<decimal>(nullable: false),
                    CursosCursoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.InscripcionID);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Curso_CursosCursoID",
                        column: x => x.CursosCursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Persona_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_CursoID",
                table: "Asignacion",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_InstructorID",
                table: "Asignacion",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_CategoriaID",
                table: "Curso",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_CursosCursoID",
                table: "Inscripcion",
                column: "CursosCursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_EstudianteID",
                table: "Inscripcion",
                column: "EstudianteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignacion");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
