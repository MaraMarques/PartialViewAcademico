﻿namespace Academico.Models
{
    public class CursoDisciplina
    {
        public long DisciplinaID { get; set; }
        public Disciplina? Disciplina { get; set; }
        public int CursoID { get; set; }
        public Curso? Curso { get; set; }
    }
}
