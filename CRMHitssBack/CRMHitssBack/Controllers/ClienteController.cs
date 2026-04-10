using CRMHitssBack.Models.Entities;
using CRMHitssBack.Service.ClienteServ;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMHitssBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController(IClienteService clienteService) : ControllerBase
    {
        private readonly IClienteService _clienteService = clienteService;

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _clienteService.TraerClientesServ();
        }

        // POST api/<ClienteController>
        [HttpPost]
        public Cliente? Post([FromBody] Cliente cliente)
        {
            return _clienteService.CrearClienteServ(cliente);
        }
    }
}
