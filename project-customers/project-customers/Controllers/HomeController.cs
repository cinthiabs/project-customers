using Microsoft.AspNetCore.Mvc;
using project_customers.Models;
using project_customers.Services;
using System.Diagnostics;

namespace project_customers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IClienteService _service;
        public HomeController(ILogger<HomeController> logger, IClienteService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index(string? nome_razao_social, string? email, string? telefone, DateTime? data_cadastro, bool? cliente_bloqueado)
        {
            if (data_cadastro == null)
            {
                data_cadastro = DateTime.MinValue;
            }

            if (string.IsNullOrEmpty(nome_razao_social) &&
                 string.IsNullOrEmpty(email) &&
                 string.IsNullOrEmpty(telefone) &&
                 cliente_bloqueado == null)
            {
                return View(await _service.GetClientes());
            }
            else
            {
                return await ClienteByFilter(nome_razao_social, email, telefone, data_cadastro, cliente_bloqueado);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ClienteByFilter(string? nome_razao_social, string? email, string? telefone, DateTime? data_cadastro, bool? cliente_bloqueado)
        {
            var clienteModel = new ClientesModel
            {
                RazaoSocial = nome_razao_social,
                Email = email,
                Telefone = telefone,
                DataCadastro = data_cadastro,
                StatusCliente = cliente_bloqueado
            };

            return View(await _service.ClienteByFilter(clienteModel));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
