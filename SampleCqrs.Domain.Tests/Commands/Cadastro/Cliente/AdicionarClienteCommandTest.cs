using NUnit.Framework;
using SampleCqrs.Domain.Commands.Cadastro.Cliente;

namespace SampleCqrs.Domain.Tests.Commands.Cadastro.Cliente
{
    [TestFixture]
    public class AdicionarClienteCommandTest
    {
        [Test]
        public void Deve_Retornar_Nome_Do_Cliente_Valido_No_Comando_Adicionar_Cliente()
        {
            var nome = "André";
            var email = "contato@gmail.com";

            var adicionarClienteCommand = new AdicionarClienteCommand(nome, email);
            var commandResult = adicionarClienteCommand.EhValido();

            Assert.IsTrue(commandResult);
        }

        [Test]
        public void Deve_Retornar_Email_Do_Cliente_Valido_No_Comando_Adicionar_Cliente()
        {
            var nome = "André";
            var email = "contato@gmail.com";

            var adicionarClienteCommand = new AdicionarClienteCommand(nome, email);
            var commandResult = adicionarClienteCommand.EhValido();

            Assert.IsTrue(commandResult);
        }

        [Test]
        public void Nao_Deve_Retornar_Nome_Do_Cliente_Valido_No_Comando_Adicionar_Cliente()
        {
            var nome = "";
            var email = "contato@gmail.com";

            var adicionarClienteCommand = new AdicionarClienteCommand(nome, email);
            var commandResult = adicionarClienteCommand.EhValido();

            Assert.IsFalse(commandResult);
        }

        [Test]
        public void Nao_Deve_Retornar_Email_Do_Cliente_Valido_No_Comando_Adicionar_Cliente()
        {
            var nome = "Andre";
            var email = "";

            var adicionarClienteCommand = new AdicionarClienteCommand(nome, email);
            var commandResult = adicionarClienteCommand.EhValido();

            Assert.IsFalse(commandResult);
        }
    }
}