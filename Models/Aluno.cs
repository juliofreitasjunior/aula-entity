using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace aec_mvc_entity_framework.Models
{[Table("alunos")]
public class Aluno{[Key][Column("id")]
public int Id { get;set; }
[Column("nome", TypeName = "varchar")][MaxLength(150)][Required]
public string Nome { get;set; }
[Column("matricula", TypeName = "varchar")][MaxLength(10)][Required]
public string Matricula { get;set; }[Column("notas", TypeName = "text")][Required]

public string Notas { get;set; }
    }
}