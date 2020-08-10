using NUnit.Framework;
using SampleCqrs.Domain.Models.Movimento;
using System;

namespace SampleCqrs.Domain.Tests.Models.Movimento
{
    [TestFixture]
    public class PedidoTest
    {
        [Test]
        public void Deve_Retornar_O_Numero_Do_Pedido_Valido()
        {
            var numeroDoPedido = 1;
            var clienteId = Guid.Empty;

            var pedido = new Pedido(numeroDoPedido, clienteId);

            Assert.AreEqual(numeroDoPedido, pedido.Numero);
        }

        [Test]
        public void Deve_Retornar_Identificador_Do_Cliente_Do_Pedido_Valido()
        {
            var numeroDoPedido = 1;
            var clienteId = Guid.NewGuid();

            var pedido = new Pedido(numeroDoPedido, clienteId);

            Assert.AreEqual(clienteId, pedido.ClienteId);
        }

        [Test]
        public void Deve_Retornar_Numero_E_Identificador_Do_Cliente_Do_Pedido_Valido()
        {
            var numeroDoPedido = 1;
            var clienteId = Guid.NewGuid();

            var pedido = new Pedido(numeroDoPedido, clienteId);

            Assert.AreEqual(numeroDoPedido, pedido.Numero);
            Assert.AreEqual(clienteId, pedido.ClienteId);
        }
    }
}