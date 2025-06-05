using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadSuasApi.Models;

[Table("FichaCadastralPessoal")]
public class FichaCadastralPessoal
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(250)]
    public string? Nome { get; set; }
    [Required]
    public char Sexo { get; set; }
    [StringLength(250)]
    public string? Endereco { get; set; }
    [StringLength(40)]
    public string? NumeroEndereco { get; set; }
    [StringLength(9)]
    public string? Cep { get; set; }
    [Required]
    [StringLength(50)]
    public string? Bairro { get; set; }
    [StringLength(11)]
    public string? Telefone { get; set; }
    [StringLength(10)]
    public string? Rg { get; set; }
    public DateOnly? DataDaExpedicao { get; set; }
    public string? UfExpedidora { get; set; }
    [Required]
    [StringLength(11)]
    public string? Cpf { get; set; }
    [Required]
    public DateOnly? DataNascimento { get; set; }
    public int TituloEleitor { get; set; }
    [StringLength(5)]
    public string? Zona { get; set; }
    [StringLength(5)]
    public string? Secao { get; set; }
    [StringLength(40)]
    public string? Escolaridade { get; set; }
    [StringLength(100)]
    public string? Profissao { get; set; }
    [StringLength(40)]
    public string? RegistroProfssional { get; set; }

    [JsonIgnore]
    public FichaCadastralProfissional? FichaCadastralProfissional { get; set; }
}