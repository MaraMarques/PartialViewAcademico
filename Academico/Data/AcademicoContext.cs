using Academico.Models;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data
{
    public class AcademicoContext : DbContext
    {
        public AcademicoContext(DbContextOptions<AcademicoContext> options) : base(options)
        {
        }
        public DbSet<Instituicao> Instituicoes { get; set;}
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<CursoDisciplina> CursosDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoDisciplina>()
                .HasKey(cd => new { cd.DisciplinaID, cd.CursoID });

            modelBuilder.Entity<CursoDisciplina>()
            .HasOne(cd => cd.Curso)
            .WithMany(c => c.CursosDisciplinas)
            .HasForeignKey(cd => cd.CursoID);

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(cd => cd.Disciplina)
                .WithMany(d => d.CursosDisciplinas)
                .HasForeignKey(cd => cd.DisciplinaID);
        }

    }
}
