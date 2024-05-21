using project_customers.Models;

namespace project_customers.Repository.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ClientesModel>> GetClientes();
        Task<ClientesModel> GetClienteByID(int clienteid);
        Task<ClientesModel> CreateCliente(ClientesModel cliente);
        Task<List<ClientesModel>> GetClienteByFilter(ClientesModel cliente);
        Task<ClientesModel> ValidateCreateCliente(ClientesModel cliente);
        Task<ClientesModel> UpdateCliente(ClientesModel cliente);
    }
}
