using RegistroDeClientes.Domain.Entities;
using RegistroDeClientes.Domain.Interfaces;

namespace RegistroDeClientes.Infra.Repositories
{
    public class ClienteRepositorie : IClienteRepositorie
    {
        private readonly DataContext _context;
        public ClienteRepositorie(DataContext context)
        {
            _context = context;
        }

        public Cliente CriarCliente(string nome, string email)
        {
            var cliente = new Cliente();
            try
            {
                cliente.NomeCliente = nome;
                cliente.EMail = email;
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return cliente;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Criar Cliente");
            }
        }

        public IEnumerable<Cliente> ConsultarClientesDaBase()
        {
            try
            {
                return _context.Clientes.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Consultar Clientes");
            }
        }

        public IQueryable<Cliente> ConsultarClientePorEmail(string email)
        {
            try
            {
                return _context.Clientes.Where(x => x.EMail == email);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Consultar Cliente");
            }
        }

        public Cliente AtualizarClientePorNome(string nome, int id)
        {
            var cliente = _context.Clientes.First(x => x.Id == id);
            try
            {
                cliente.NomeCliente = nome;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Modificar Cliente");
            }
            return cliente;
        }
        public Cliente AtualizarClientePorEmail(string email, int id)
        {
            var cliente = _context.Clientes.First(x => x.Id == id);
            try
            {
                cliente.EMail = email;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Modificar Cliente");
            }
            return cliente;
        }
        public Cliente DeletarClientePorEmail(string email)
        {
            if (email == null)
            {
                return null;
            }
            var cliente = _context.Clientes.First(x => x.EMail == email);
            try
            {
                _context.Remove(cliente);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Deletar Cliente");
            }
            return cliente;
        }
    }
}
