using NSubstitute;
using NUnit.Framework;
using SampleCqrs.Domain.Commands.Cadastro.Cliente;
using SampleCqrs.Domain.Commands.Handlers.Cadastro.Cliente;
using SampleCqrs.Domain.Core.Enums.Responses;
using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Interfaces.UnitOfWork;
using System.Linq;
using System.Threading;
using ClienteModel = SampleCqrs.Domain.Models.Cadastro.Cliente;

namespace SampleCqrs.Domain.Tests.Commands.Handlers.Cadastro.Cliente
{
    [TestFixture]
    public class AdicionarClienteHandlerTest
    {
        private IClienteRepository clienteRepository;
        private IUnitOfWork unitOfWork;

        [Test]
        public void Deve_Adicionar_Cliente()
        {
            //Arrange
            var adicionarClienteCommand = new AdicionarClienteCommand("André", "contato@gmail.com");

            clienteRepository.GetByEmail(adicionarClienteCommand.Email).Returns((ClienteModel)null);
            unitOfWork.Commit().Returns(true);

            //Act
            var adicionarClienteHandler = new AdicionarClienteHandler(clienteRepository, unitOfWork);
            var commandResult = adicionarClienteHandler.Handle(adicionarClienteCommand, new CancellationToken());

            //Assert
            Assert.AreEqual(ResponseStatus.Sucesso, commandResult.Result.Status);
        }

        [Test]
        public void Deve_Retornar_Erro_De_Validacao_Quando_Nome_Do_Cliente_Eh_Invalido()
        {
            //Arrange
            var adicionarClienteCommand = new AdicionarClienteCommand("", "contato@gmail.com");

            //Act
            var adicionarClienteHandler = new AdicionarClienteHandler(clienteRepository, unitOfWork);
            var commandResult = adicionarClienteHandler.Handle(adicionarClienteCommand, new CancellationToken());

            //Assert
            Assert.AreEqual("Nome é obrigatório.", commandResult.Result.Erros.FirstOrDefault());
        }

        [Test]
        public void Deve_Retornar_Erro_De_Validacao_Quando_Email_Do_Cliente_Eh_Invalido()
        {
            //Arrange
            var adicionarClienteCommand = new AdicionarClienteCommand("Andre", "");

            //Act
            var adicionarClienteHandler = new AdicionarClienteHandler(clienteRepository, unitOfWork);
            var commandResult = adicionarClienteHandler.Handle(adicionarClienteCommand, new CancellationToken());

            //Assert
            Assert.AreEqual("E-mail é obrigatório.", commandResult.Result.Erros.FirstOrDefault());
        }

        [Test]
        public void Deve_Retornar_Erro_De_Validacao_Quando_Ja_Existe_Email_Do_Cliente()
        {
            //Arrange
            var adicionarClienteCommand = new AdicionarClienteCommand("Andre", "contato@gmail.com");
            clienteRepository.GetByEmail(adicionarClienteCommand.Email).Returns(new ClienteModel(
                nome: adicionarClienteCommand.Nome,
                email: adicionarClienteCommand.Email
                ));

            //Act
            var adicionarClienteHandler = new AdicionarClienteHandler(clienteRepository, unitOfWork);
            var commandResult = adicionarClienteHandler.Handle(adicionarClienteCommand, new CancellationToken());

            //Assert
            Assert.AreEqual($"Já existe cliente com este e-mail: {adicionarClienteCommand.Email}.", commandResult.Result.Erros.FirstOrDefault());
        }

        [Test]
        public void Deve_Retornar_Erro_Ao_Adicionar_Cliente()
        {
            //Arrange
            var adicionarClienteCommand = new AdicionarClienteCommand("Andre", "contato@gmail.com");
            clienteRepository.GetByEmail(adicionarClienteCommand.Email).Returns((ClienteModel)null);
            unitOfWork.Commit().Returns(false);

            //Act
            var adicionarClienteHandler = new AdicionarClienteHandler(clienteRepository, unitOfWork);
            var commandResult = adicionarClienteHandler.Handle(adicionarClienteCommand, new CancellationToken());

            //Assert
            Assert.AreEqual("Ocorreu um erro ao salvar o cliente.", commandResult.Result.Erros.FirstOrDefault());
        }

        [SetUp]
        public void Setup()
        {
            clienteRepository = Substitute.For<IClienteRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
        }
    }
}