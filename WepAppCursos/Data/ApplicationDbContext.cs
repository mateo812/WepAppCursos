using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WepAppCursos.Models;

namespace WepAppCursos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WepAppCursos.Models.Asignacion> Asignacion { get; set; }
        public DbSet<WepAppCursos.Models.Categoria> Categoria { get; set; }
        public DbSet<WepAppCursos.Models.Curso> Curso { get; set; }
        public DbSet<WepAppCursos.Models.Estudiante> Estudiante { get; set; }
        public DbSet<WepAppCursos.Models.Inscripcion> Inscripcion { get; set; }
        public DbSet<WepAppCursos.Models.Instructor> Instructor { get; set; }

        public DbSet<WepAppCursos.Models.Persona> Persona { get; set; }
    }
}
