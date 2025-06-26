using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadSuasApi.DTO.FichasPessoais
{
    public class FichaCadastralPessoalDTOResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public char Sexo { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroEndereco { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Telefone { get; set; }
        public string? Rg { get; set; }
        public DateOnly? DataDaExpedicao { get; set; }
        public string? UfExpedidora { get; set; }
        public string? Cpf { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public int TituloEleitor { get; set; }
        public string? Zona { get; set; }
        public string? Secao { get; set; }
        public string? Escolaridade { get; set; }
        public string? Profissao { get; set; }
        public string? RegistroProfssional { get; set; }
    }
}