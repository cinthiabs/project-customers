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
                response.Mensagem = "Já cadastrado";
                response.Sucesso = false;
                response.Dados = validate;
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

        public Task<List<ClientesModel>> ClienteByFilter(ClientesModel cliente)
        {
           var clienteByFilter = _repository.GetClienteByFilter(cliente);
            return clienteByFilter;
        }
        public Task<ClientesModel> ValidateCreateCliente(ClientesModel cliente)
        {
            var clienteByFilter = _repository.ValidateCreateCliente(cliente);
            return clienteByFilter;
        }

        public Task<ClientesModel> UpdateCliente(ClientesModel cliente)
        {
            var clienteupdated = _repository.UpdateCliente(cliente);
            return clienteupdated;
        }
    }
}
