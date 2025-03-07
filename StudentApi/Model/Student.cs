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
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string Sobrenome { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [Column(TypeName = "varchar(255)")]
    public string Matricula { get; set; } = string.Empty;

    [Column(TypeName = "varchar(20)")] // Adjust length as needed
    public string Telefone { get; set; } = string.Empty; // Single phone number as a string
}