using NSubstitute;
using NUnit.Framework;
using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Queries.Cadastro.Cliente;
using SampleCqrs.Domain.Queries.Handlers.Cadastro.Cliente;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ClienteModel = SampleCqrs.Domain.Models.Cadastro.Cliente;

namespace SampleCqrs.Domain.Tests.Queries.Handlers.Cadastro.Cliente
{
    [TestFixture]
    public class ListarClienteHandlerTest
    {
        private IClienteRepository clienteRepository;

        [Test]
        public void Deve_Retornar_Todos_Os_Clientes()
        {
            //Arrange
            var quantidadeDeClientes = 3;
            clienteRepository.GetAll().Returns(new List<ClienteModel>
            {
                new ClienteModel("Andre", "contato@gmail.com"),
                new ClienteModel("Jose", "contato@gmail.com"),
                new ClienteModel("Bruno", "contato@gmail.com")
            });

            //Act
            var listarClienteHandler = new ListarClienteHandler(clienteRepository);
            var queryResult = listarClienteHandler.Handle(new ListarClienteQuery(), new CancellationToken());

            //Assert
            Assert.AreEqual(quantidadeDeClientes, queryResult.Result.Dados.Count);
        }

        [Test]
        public void Nao_Deve_Retornar_Todos_Os_Clientes()
        {
            //Arrange
            clienteRepository.GetAll().Returns(new List<ClienteModel>());

            //Act
            var listarClienteHandler = new ListarClienteHandler(clienteRepository);
            var queryResult = listarClienteHandler.Handle(new ListarClienteQuery(), new CancellationToken());

            //Assert
            Assert.IsTrue(!queryResult.Result.Dados.Any());
        }

        [SetUp]
        public void Setup()
        {
            clienteRepository = Substitute.For<IClienteRepository>();
        }
    }
}