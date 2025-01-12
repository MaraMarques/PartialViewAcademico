﻿// <auto-generated />
using Academico.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Academico.Migrations
{
    [DbContext(typeof(AcademicoContext))]
    [Migration("20240618175047_att")]
    partial class att
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Academico.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<long>("DepartamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Academico.Models.CursoDisciplina", b =>
                {
                    b.Property<long>("DisciplinaID")
                        .HasColumnType("bigint");

                    b.Property<int>("CursoID")
                        .HasColumnType("int");

                    b.HasKey("DisciplinaID", "CursoID");

                    b.HasIndex("CursoID");

                    b.ToTable("CursosDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Departamento", b =>
                {
                    b.Property<long>("DepartamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DepartamentoID"));

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartamentoID");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Academico.Models.Disciplina", b =>
                {
                    b.Property<long>("DisciplinaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DisciplinaID"));

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DisciplinaID");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("Academico.Models.Instituicao", b =>
                {
                    b.Property<int>("InstituicaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstituicaoID"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstituicaoID");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("Academico.Models.Curso", b =>
                {
                    b.HasOne("Academico.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Academico.Models.CursoDisciplina", b =>
                {
                    b.HasOne("Academico.Models.Curso", "Curso")
                        .WithMany("CursosDisciplinas")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academico.Models.Disciplina", "Disciplina")
                        .WithMany("CursosDisciplinas")
                        .HasForeignKey("DisciplinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("Academico.Models.Departamento", b =>
                {
                    b.HasOne("Academico.Models.Instituicao", "Instituicao")
                        .WithMany()
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("Academico.Models.Curso", b =>
                {
                    b.Navigation("CursosDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Disciplina", b =>
                {
                    b.Navigation("CursosDisciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
