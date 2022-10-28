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
    class AdminTest
    {
        [Test]
        public void TestRegisterSuccess()
        {
            var mock = new Mock<IAdminRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.Registrar(new Account() { Tipo = "Mecanico", Estado = true })); //null
            var controller = new AdminController(null, mock.Object, viewBagMock.Object);
            var result = controller.Registrar(new Account() { Tipo = "Mecanico", Estado = true }) as RedirectToActionResult; //null

            Assert.IsInstanceOf<RedirectToActionResult>(result);

        }
        [Test]
        public void TestRegisterFail()
        {
            var mock = new Mock<IAdminRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.Registrar(null));                         //datos
            var controller = new AdminController(null, mock.Object, viewBagMock.Object);
            var result = controller.Registrar(null) as ViewResult;      //datos

            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void TestListMecanicos()
        {
            var mock = new Mock<IAdminRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.GetAllMecanicos(null));
            var controller = new AdminController(null, mock.Object, viewBagMock.Object);
            var result = controller.ListMeca(null) as ViewResult; //RedirectToActionResult  

            Assert.IsInstanceOf<ViewResult>(result); //RedirectToActionResult
        }
        [Test]
        public void TestSearchMecanico()
        {
            var mock = new Mock<IAdminRepository>();
            var viewBagMock = new Mock<IAccountViewBagManager>();
            mock.Setup(o => o.GetAllMecanicos("piero"));
            var controller = new AdminController(null, mock.Object, viewBagMock.Object);
            var result = controller.ListMeca("piero") as ViewResult; //RedirectToActionResult

            Assert.IsInstanceOf<ViewResult>(result); //RedirectToActionResult
        }
    }
}
