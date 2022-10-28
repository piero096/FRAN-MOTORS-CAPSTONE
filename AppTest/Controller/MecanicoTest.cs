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
    class MecanicoTest
    {
        [Test]
        public void TestRegisterClienteSuccess()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.RegistrarCliente(new Cliente(), null));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.Register(new Cliente(), null) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);

        }
        [Test]
        public void TestRegisterClienteFail()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.RegistrarCliente(null,null));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.Register(null,null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void TestListClientes()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.GetAllClientes(""));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.AllClientes("") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestRegisterMoto()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.RegisterMoto(12, new Motocicleta(), null, null));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.RegisterMoto(12, new Motocicleta(), null, null) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestListMotoForCliente()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.ListMotoForClient(12));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.ListMoto(12) as ViewResult; //RedirectToActionResult

            Assert.IsInstanceOf<ViewResult>(result); //RedirectToActionResult
        }
        [Test]
        public void TestRegisterHistory()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.RegistrarHistoria(12, new Historial(), 10));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.RegHistory(12, new Historial(), 10) as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestListHistory()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.LisHistorialForMoto(12, 10));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.VerHistoria(12, 10) as ViewResult; //RedirectToActionResult

            Assert.IsInstanceOf<ViewResult>(result); //RedirectToActionResult
        }
        [Test]
        public void TestEditMoto()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.EditarMoto(new Motocicleta(), 10));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.EditMoto(new Motocicleta(), 10) as ViewResult; //RedirectToActionResult

            
        }
        [Test]
        public void TestSearchClientes()
        {
            var mock = new Mock<IMecanicoRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.GetAllClientes("piero"));
            var controller = new MecanicoController(null, mock.Object, viewBagMock.Object);
            var result = controller.AllClientes("piero") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }


    }
}
