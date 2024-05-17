using project_customers.Models;

namespace project_customers.Services
{
    public interface IClienteService
    {
        Task<List<ClientesModel>> GetClientes();
        Task<ResponseModel<string>> CreateCliente(ClientesModel cliente);
        Task<List<ClientesModel>> GetEmployeeByFilter(int id);
        Task<ResponseModel<string>> UpdateEmployee(ClientesModel cliente);
    }
}
