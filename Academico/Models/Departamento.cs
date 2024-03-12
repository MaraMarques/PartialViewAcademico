using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Departamento
    {
        [Key] // Anotação para indicar que é a chave primária
        public long DepartamentoID { get; set; }

        // Campo Nome do tipo string
        [Required] // Anotação para indicar que o campo é obrigatório
        [StringLength(100)] // Anotação para limitar o tamanho máximo do nome
        public string Nome { get; set; }
    }
}
