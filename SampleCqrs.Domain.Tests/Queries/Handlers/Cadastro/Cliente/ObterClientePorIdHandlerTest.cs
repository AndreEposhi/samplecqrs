using NSubstitute;
using NUnit.Framework;
using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Queries.Cadastro.Cliente;
using SampleCqrs.Domain.Queries.Handlers.Cadastro.Cliente;
using System;
using System.Linq;
using System.Threading;
using ClienteModel = SampleCqrs.Domain.Models.Cadastro.Cliente;

namespace SampleCqrs.Domain.Tests.Queries.Handlers.Cadastro.Cliente
{
    [TestFixture]
    public class ObterClientePorIdHandlerTest
    {
        private IClienteRepository clienteRepository;

        [Test]
        public void Deve_Retornar_Cliente_Por_Id()
        {
            //Arrange
            var id = Guid.NewGuid();
            var obterClientePorIdQuery = new ObterClientePorIdQuery(id);
            clienteRepository.GetById(id).Returns(new ClienteModel("Andre", "contato@gmail.com"));

            //Act
            var obterClientePorIdHandler = new ObterClientePorIdHandler(clienteRepository);
            var queryResult = obterClientePorIdHandler.Handle(obterClientePorIdQuery, new CancellationToken());

            var cliente = queryResult.Result.Dados.FirstOrDefault() as ClienteModel;

            //Assert
            Assert.AreEqual("Andre", cliente.Nome);
        }

        [Test]
        public void Deve_Retornar_Cliente_Nao_Localizado()
        {
            //Arrange
            var id = Guid.NewGuid();
            var obterClientePorIdQuery = new ObterClientePorIdQuery(id);
            clienteRepository.GetById(id).Returns((ClienteModel)null);

            //Act
            var obterClientePorIdHandler = new ObterClientePorIdHandler(clienteRepository);
            var queryResult = obterClientePorIdHandler.Handle(obterClientePorIdQuery, new CancellationToken());

            //Assert
            Assert.AreEqual("Cliente não localizado.", queryResult.Result.Erros.FirstOrDefault());
        }

        [SetUp]
        public void Setup()
        {
            clienteRepository = Substitute.For<IClienteRepository>();
        }
    }
}