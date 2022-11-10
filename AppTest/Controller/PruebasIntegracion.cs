using FranMotors.Controllers;
using FranMotors.Manager;
using FranMotors.Models;
using FranMotors.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Controller
{
    class PruebasIntegracion
    {
        [Test]
        public void TestRegisterMecanicoAndClienteSuccess()
        {
            var mock = new Mock<IAdminRepository>();
            var mock2 = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.Registrar(new Account() { Tipo = "Mecanico", Estado = true })); //null
            mock2.Setup(o => o.RegistrarCliente(new Cliente(), null)); //null
            var controller = new AdminController(null, mock.Object, viewBagMock.Object);
            var controller2 = new MecanicoController(null, mock2.Object, viewBagMock.Object);
            var result = controller.Registrar(new Account() { Tipo = "Mecanico", Estado = true }) as RedirectToActionResult; //null
            var result1 = controller2.Register(new Cliente(),null) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result1);

        }
        [Test]
        public void TestRegisterMecanicoAndClienteSuccessFail()
        {
            var mock = new Mock<IAdminRepository>();
            var mock2 = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.Registrar(null)); //null
            mock2.Setup(o => o.RegistrarCliente(null, null)); //null
            var controller = new AdminController(null, mock.Object, viewBagMock.Object);
            var controller2 = new MecanicoController(null, mock2.Object, viewBagMock.Object);
            var result = controller.Registrar(null) as ViewResult; //null
            var result1 = controller2.Register(null,null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<ViewResult>(result1);
        }
    }
}
