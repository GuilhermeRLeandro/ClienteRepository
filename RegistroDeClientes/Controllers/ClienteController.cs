using Microsoft.AspNetCore.Mvc;
using RegistroDeClientes.Domain.Entities;
using RegistroDeClientes.Service.Interfaces;

namespace RegistroDeClientes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _cliente;

        public ClienteController(IClienteService cliente)
        {
            _cliente = cliente;
        }

        [HttpPost(Name = "CriarCliente")]
        public IActionResult CriarCliente(string nome, string email)
        {
            return Ok(_cliente.CadastrarCliente(nome, email));
        }

        [HttpGet(Name = "ConsultarClientesDaBase")]
        public IEnumerable<Cliente> ConsultarClientesDaBase()
        {
            return _cliente.BuscarClientesDaBase();
        }

        [HttpGet(Name = "ConsultarClientePorEmail")]
        public IEnumerable<Cliente> ConsultarClientePorEmail(string email)
        {
            return _cliente.BuscarClientesPorEmail(email);
        }

        [HttpPut(Name = "AtualizarClientePorNome")]
        public IActionResult AtualizarClientePorNome(string nome, int id)
        {
            return Ok(_cliente.MudarNomeCliente(nome, id));
        }

        [HttpPut(Name = "AtualizarClientePorEmail")]
        public IActionResult AtualizarClientePorEmail(string email, int id)
        {
            return Ok(_cliente.MudarEmailCliente(email, id));
        }

        [HttpDelete(Name = "DeletarClientePorEmail")]
        public IActionResult DeletarClientePorEmail(string email)
        {       
            return Ok(_cliente.ExcluirClientePorEmail(email));
        }
    }
}