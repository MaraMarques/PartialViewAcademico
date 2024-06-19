using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Academico.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [IntegerValidator(MinValue = 20)]
        public int CargaHoraria { get; set; }
        public long DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public List<CursoDisciplina>? CursosDisciplinas { get; set; }
    }
}
