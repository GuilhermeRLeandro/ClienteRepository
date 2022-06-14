using Moq;
using RegistroDeClientes.Domain.Entities;
using RegistroDeClientes.Domain.Interfaces;
using RegistroDeClientes.Service.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace RegistroDeClientes.Teste
{
    public class ClienteServiceTeste
    {
        private readonly ClienteService _clienteService;
        private readonly Mock<IClienteRepositorie> _clienteRepositorie = new();

        public ClienteServiceTeste()
        {
            _clienteService = new ClienteService(_clienteRepositorie.Object);
        }

        [Fact]
        public void CriarCliente_NotNull_Sucess()
        {
            var cliente = new Cliente();
            _clienteRepositorie.Setup(x => x.CriarCliente("guilherme", "gui@gui"))
                .Returns(cliente);

            var result = _clienteService.CadastrarCliente("guilherme", "gui@gui");
            Assert.IsType<Cliente>(result);
            Assert.NotNull(result);
            Assert.Equal(result, cliente);
        }

        [Fact]
        public void BuscarClientes_NotNull_Sucess()
        {
            var cliente = new Cliente();
            _clienteRepositorie.Setup(x => x.CriarCliente("guilherme", "gui@gui"))
                .Returns(cliente);
            var result = _clienteService.BuscarClientesDaBase();
            Assert.IsType<Cliente[]>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void BuscarClientesPorEmail_Null_Sucess()
        {
            var result = _clienteService.BuscarClientesPorEmail(null);
            Assert.Null(result);
        }

        [Fact]
        public void AlterarClientePorNome_NotNull_Sucess()
        {
            var result = _clienteService.MudarNomeCliente(null, 123456);
            Assert.Null(result);
        }

        [Fact]
        public void AlterarClientePorEmail_NotNull_Sucess()
        {
            var result = _clienteService.MudarEmailCliente(null, 123456);
            Assert.Null(result);
        }

        [Fact]
        public void DeletarClientePorEmail_Null_Sucess()
        {
            var result = _clienteService.ExcluirClientePorEmail(null);
            Assert.Null(result);
        }
    }
}