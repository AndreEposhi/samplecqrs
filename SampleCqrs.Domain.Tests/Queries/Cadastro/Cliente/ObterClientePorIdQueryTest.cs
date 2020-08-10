using NUnit.Framework;
using SampleCqrs.Domain.Queries.Cadastro.Cliente;
using System;

namespace SampleCqrs.Domain.Tests.Queries.Cadastro.Cliente
{
    [TestFixture]
    public class ObterClientePorIdQueryTest
    {
        [Test]
        public void Deve_Obter_Cliente_Por_Id()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var cliente = new ObterClientePorIdQuery(id);

            //Assert
            Assert.AreEqual(id, cliente.Id);
        }
    }
}