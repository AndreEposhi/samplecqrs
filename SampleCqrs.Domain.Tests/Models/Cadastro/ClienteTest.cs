using NUnit.Framework;
using SampleCqrs.Domain.Models.Cadastro;

namespace SampleCqrs.Domain.Tests.Models.Cadastro
{
    [TestFixture]
    public class ClienteTest
    {
        [Test]
        public void Deve_Retornar_Nome_Do_Cliente_Valido()
        {
            var nome = "André";
            var email = "";

            var cliente = new Cliente(nome, email);

            Assert.AreEqual(nome, cliente.Nome);
        }

        [Test]
        public void Deve_Retornar_Email_Do_Cliente_Valido()
        {
            var nome = "";
            var email = "andre@gmail.com";

            var cliente = new Cliente(nome, email);

            Assert.AreEqual(email, cliente.Email);
        }

        [Test]
        public void Deve_Retornar_Nome_E_Email_Do_Cliente_Valido()
        {
            var nome = "André";
            var email = "andre@gmail.com";

            var cliente = new Cliente(nome, email);

            Assert.AreEqual(nome, cliente.Nome);
            Assert.AreEqual(email, cliente.Email);
        }

        [Test]
        public void Deve_Alterar_O_Nome_Do_Cliente()
        {
            var nome = "André";
            var email = "andre@gmail.com";

            var cliente = new Cliente(nome, email);

            Assert.AreEqual(nome, cliente.Nome);

            nome = "Luiz";

            cliente.ChangeInformation(nome, email);

            Assert.AreEqual(nome, cliente.Nome);
        }

        [Test]
        public void Deve_Alterar_O_Email_Do_Cliente()
        {
            var nome = "André";
            var email = "andre@gmail.com";

            var cliente = new Cliente(nome, email);

            Assert.AreEqual(email, cliente.Email);

            email = "contato@gmail.com";

            cliente.ChangeInformation(nome, email);

            Assert.AreEqual(email, cliente.Email);
        }

        [Test]
        public void Deve_Alterar_O_Nome_E_Email_Do_Cliente()
        {
            var nome = "André";
            var email = "andre@gmail.com";

            var cliente = new Cliente(nome, email);

            Assert.AreEqual(nome, cliente.Nome);
            Assert.AreEqual(email, cliente.Email);

            nome = "Luiz";
            email = "luiz@gmail.com";

            cliente.ChangeInformation(nome, email);

            Assert.AreEqual(nome, cliente.Nome);
            Assert.AreEqual(email, cliente.Email);
        }
    }
}