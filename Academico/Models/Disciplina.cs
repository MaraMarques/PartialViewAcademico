using System.Configuration;

namespace Academico.Models
{
    public class Disciplina
    {
        public long DisciplinaID { get; set; }
        public string Nome { get; set; }
        [IntegerValidator(MinValue = 20)]
        public int CargaHoraria { get; set; }
        public List<CursoDisciplina>? CursosDisciplinas { get; set; }
    }
}
