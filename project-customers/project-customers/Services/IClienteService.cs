using project_customers.Models;

namespace project_customers.Services
{
    public interface IClienteService
    {
        Task<List<ClientesModel>> GetClientes();
        Task<ResponseModel<ClientesModel>> CreateCliente(ClientesModel cliente);
        Task<List<ClientesModel>> ClienteByFilter(ClientesModel cliente);
        Task<ClientesModel> ValidateCreateCliente(ClientesModel cliente);

        Task<ClientesModel> UpdateCliente(ClientesModel cliente);
    }
}
