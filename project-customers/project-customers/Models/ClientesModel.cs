using project_customers.Enums;
using System.ComponentModel.DataAnnotations;

namespace project_customers.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool StatusCliente { get; set; }

        [Required(ErrorMessage = "O campo Pessoa é obrigatório.")]
        public Pessoa Pessoa { get; set; }

        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo Inscrição Estadual é obrigatório.")]
        public int InscricaoEstadual { get; set; }
        public bool Insento { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo Confirmar Senha é obrigatório.")]
        public string SenhaConfirmar { get; set; }
    }
}
