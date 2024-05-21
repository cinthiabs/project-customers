using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_customers.Models;
using project_customers.Services;

namespace project_customers.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IClienteService _service;
        public ClienteController(ILogger<HomeController> logger, IClienteService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<IActionResult> Index(ClientesModel? cliente)
        {
            if (cliente != null && cliente.CpfCnpj != null)
            {
                var result = await _service.CreateCliente(cliente);
                if (result.Sucesso == false)
                {
                    return Json(result.Mensagem);
                }
                else
                {
                    return Redirect("Home");
                }

            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> UpdateCliente(int Id)
        {
            if(Id != null)
            {
                ViewBag.ClienteId = Id;
                var result = await _service.GetClienteByID(Id);
                return View(result);
            }
            return View();
        }

        public async Task<IActionResult> CreateCliente(ClientesModel? cliente)
        {
            if (cliente != null)
            {
              var result =  await _service.CreateCliente(cliente);
                if(result.Sucesso == false)
                {
                    return Json(result.Mensagem);
                }
                else
                {
                    return Redirect("Home");
                }

            }
            else
            {
                return View();
            }

        }
    }
}
