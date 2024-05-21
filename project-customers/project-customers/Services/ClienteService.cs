using project_customers.Models;
using project_customers.Repository.ServiceRepository;

namespace project_customers.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IServiceRepository _repository;
        public ClienteService(IServiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseModel<ClientesModel>> CreateCliente(ClientesModel cliente)
        {
           ResponseModel<ClientesModel> response = new ResponseModel<ClientesModel>();
            var validate = await _repository.ValidateCreateCliente(cliente);
            if(validate != null)
            {
                response.Sucesso = false;
                response.Dados = validate;
                if (validate.Email == cliente.Email)
                {
                    response.Mensagem = "Este e-mail já está cadastrado para outro Cliente.";
                }
                if (validate.CpfCnpj == cliente.CpfCnpj)
                {
                    response.Mensagem = "Este CPF/CNPJ já está cadastrado para outro Cliente";
                }
                if (validate.InscricaoEstadual == cliente.InscricaoEstadual)
                {
                    response.Mensagem = "Esta Inscrição Estadual já está cadastrada para outro Cliente";
                }

            }
            else
            {
                cliente.DataCadastro = DateTime.Now;
                var created = await _repository.CreateCliente(cliente);
                response.Mensagem = "Sucesso";
                response.Sucesso = true;
                response.Dados = created;
            }
            return response;

        }

        public Task<List<ClientesModel>> GetClientes()
        {
            var clientes = _repository.GetClientes();
            return clientes;
        }

        public async Task<List<ClientesModel>> ClienteByFilter(ClientesModel cliente)
        {
           var clienteByFilter = await _repository.GetClienteByFilter(cliente);
            return clienteByFilter;
        }
        public async Task<ClientesModel> ValidateCreateCliente(ClientesModel cliente)
        {
            var clienteByFilter = await _repository.ValidateCreateCliente(cliente);
            return clienteByFilter;
        }

        public async Task<ClientesModel> UpdateCliente(ClientesModel cliente)
        {
            var clienteupdated = await _repository.UpdateCliente(cliente);
            return clienteupdated;
        }

        public async Task<ClientesModel> GetClienteByID(int clienteid)
        {
            var cliente = await _repository.GetClienteByID(clienteid);
            return cliente;
        }
    }
}
