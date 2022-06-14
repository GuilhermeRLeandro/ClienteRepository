using RegistroDeClientes.Domain.Entities;

namespace RegistroDeClientes.Domain.Interfaces
{
    public interface IClienteRepositorie
    {
        Cliente CriarCliente(string nome, string email);
        IEnumerable<Cliente> ConsultarClientesDaBase();
        IQueryable<Cliente> ConsultarClientePorEmail(string email);
        Cliente AtualizarClientePorNome(string nome, int id);
        Cliente AtualizarClientePorEmail(string email, int id);
        Cliente DeletarClientePorEmail(string email);
    }
}
