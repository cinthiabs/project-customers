using project_customers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_customers.Models
{
    public class ClientesModel
    {
        public int? Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool? StatusCliente { get; set; }
        public Pessoa? Pessoa { get; set; }
        public string? CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public bool? Insento { get; set; }
        public Genero? Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmar { get; set; }
    }
}
