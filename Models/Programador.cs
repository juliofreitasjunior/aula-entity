using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace aec_mvc_entity_framework.Models
{
[Table("Programadores")]
public class Programador{

[Key][Column("id")]

public int Codigo { get;set; }

[Column("nome", TypeName = "varchar")]
[MaxLength(120)]
[Required]

public string Nome { get;set; }

[Column("telefone", TypeName = "varchar")]
[MaxLength(20)]
[Required]
public string Tel { get;set; }


    }
}