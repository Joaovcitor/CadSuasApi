using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadSuasApi.Models;

[Table("Users")]
public class Usuario
{
    [Key]
    public int Id { get; set; }
    
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
}