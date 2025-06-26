using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadSuasApi.DTO.FichasPessoais
{
    public class FichaCadastralPessoalRequest
    {
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
    }
}