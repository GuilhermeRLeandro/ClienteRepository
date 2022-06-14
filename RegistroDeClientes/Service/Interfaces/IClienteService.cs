using RegistroDeClientes.Domain.Entities;

namespace RegistroDeClientes.Service.Interfaces
{
    public interface IClienteService
    {
        Cliente CadastrarCliente(string nome, string email);
        IEnumerable<Cliente> BuscarClientesDaBase();
        IEnumerable<Cliente> BuscarClientesPorEmail(string email);
        Cliente MudarNomeCliente(string nome, int id);
        Cliente MudarEmailCliente(string email, int id);
        Cliente ExcluirClientePorEmail(string email);

    }
}
