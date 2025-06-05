using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadSuasApi.Models;

[Table("Users")]
public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; }

    [Required, MaxLength(255)]
    public string SenhaHash { get; set; }

    [MaxLength(128)]
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }


    // aguardando quais roles serão definidas!
    [MaxLength(50)]
    public string? Role { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public DateTime? UltimoLogin { get; set; }

    public bool Ativo { get; set; } = true;
}