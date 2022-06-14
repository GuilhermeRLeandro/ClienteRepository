using RegistroDeClientes.Domain.Entities;
using RegistroDeClientes.Domain.Interfaces;
using RegistroDeClientes.Service.Interfaces;

namespace RegistroDeClientes.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorie _clienteRepositorie;

        public ClienteService(IClienteRepositorie clienteRepositorie)
        {
            _clienteRepositorie = clienteRepositorie;
        }


        public Cliente CadastrarCliente(string nome, string email)
        {
            if (nome == null || email == null)
            {
                return null;
            }

            var cliente = _clienteRepositorie.CriarCliente(nome, email);
            return cliente;
        }
        public IEnumerable<Cliente> BuscarClientesDaBase()
        {
            return _clienteRepositorie.ConsultarClientesDaBase();
        }
        public IEnumerable<Cliente> BuscarClientesPorEmail(string email)
        {
            if (email == null)
            {
                return null;
            }
            return _clienteRepositorie.ConsultarClientePorEmail(email);
        }
        public Cliente MudarNomeCliente(string nome, int id)
        {
            if (nome == null || id.GetType() != typeof(int))
            {
                return null;
            }
            return _clienteRepositorie.AtualizarClientePorNome(nome, id);
        }
        public Cliente MudarEmailCliente(string email, int id)
        {
            if (email == null || id.GetType() != typeof(int))
            {
                return null;
            }
            return _clienteRepositorie.AtualizarClientePorEmail(email, id);
        }
        public Cliente ExcluirClientePorEmail(string email)
        {
            if (email == null)
            {
                return null;
            }
            return _clienteRepositorie.DeletarClientePorEmail(email);
        }
    }
}
