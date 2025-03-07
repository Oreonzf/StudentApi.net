using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Nome { get; set; }

    [Required]
    [MinLength(3)]
    public string Sobrenome { get; set; }

    [Required]
    [MinLength(3)]
    [Column(TypeName = "varchar(255)")]
    public string Matricula { get; set; }

    public List<string> Telefones { get; set; } = new List<string>();
}