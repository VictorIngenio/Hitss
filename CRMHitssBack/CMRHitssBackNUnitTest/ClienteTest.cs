using CRMHitssBack.Controllers;
using CRMHitssBack.Models.Context;
using CRMHitssBack.Models.Entities;
using CRMHitssBack.Service.ClienteServ;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMRHitssBackNUnitTest
{
    [TestFixture]
    public class ClienteTest
    {
        private Cliente? cliente;
        private DbContextOptions<ClienteContext> options;

        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<ClienteContext>()
                            .UseInMemoryDatabase(databaseName: "CRMHitssPruebaDB").Options;

            cliente = new Cliente
            {
                Id = 1,
                Nombre = "Juan Perez",
                Email = "jperez@outlook.com",
                Telefono = "3134985338",
                NombreFinca = "La Esperanza",
                Hectareas = "200"
            };
        }

        [Test]
        [Order(1)]
        public void ClienteController_TraerTodosLosClientes()
        {
            // Arrange
            var clientes = new List<Cliente>()
            {
                new Cliente 
                {
                    Id = 1,
                    Nombre = "Juan Perez",
                    Email = "jperez@outlook.com",
                    Telefono = "3134985338",
                    NombreFinca = "La Esperanza",
                    Hectareas = "200"
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "María Gonzalez",
                    Email = "mgonzalez@gmail.com",
                    Telefono = "3208275235",
                    NombreFinca = "Los Gonzalez",
                    Hectareas = "300"
                }
            };

            var mockClienteServicio = new Mock<IClienteService>();
            mockClienteServicio.Setup(x => x.TraerClientesServ()).Returns(clientes);

            var clienteController = new ClienteController(mockClienteServicio.Object);
            var actionResult = clienteController.GetClientes();

            // Assert
            CollectionAssert.AreEqual(clientes, actionResult);
            Assert.That(clientes.Count, Is.EqualTo(actionResult.Count()));
        }

        [Test]
        [Order(2)]
        public void ClienteController_PostCliente_GuardadoExitoso()
        {
            // Arrange
            var mockClienteServicio = new Mock<IClienteService>();
            mockClienteServicio.Setup(x => x.CrearClienteServ(cliente!));

            var clienteController = new ClienteController(mockClienteServicio.Object);
            var actionResult = clienteController.Post(cliente!);

            // Assert
            Assert.That(cliente!, Is.EqualTo(actionResult));
        }
    }
}
