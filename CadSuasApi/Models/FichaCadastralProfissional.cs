using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CadSuasApi.Models;

[Table("FichaCadastralProfissional")]
public class FichaCadastralProfissional
{

    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(150)]
    public string Funcao { get; set; }
    [Required]
    public DateOnly InicioExercicioFuncao { get; set; }
    [Required]
    [StringLength(150)]
    public string Vinculo { get; set; }
    [Required]
    public int CargaHoraria { get; set; }
    [Required]
    public DateOnly DataPreencimento { get; set; }
    public int FichaCadastralPessoalId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [ForeignKey("FichaCadastralPessoalId")]
    public FichaCadastralPessoal? FichaCadastralPessoal { get; set; }

}