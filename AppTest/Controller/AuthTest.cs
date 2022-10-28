using FranMotors.Controllers;
using FranMotors.Models;
using FranMotors.Repositories;
using FranMotors.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Controller
{
    class AuthTest
    {
        [Test]
        public void TestLoginSuccess01()
        {
            var mock = new Mock<IAuthRepository>();
            var authMock = new Mock<IAuthService>();
            mock.Setup(o => o.Login("angel", "angel")).Returns(new Account() { Estado = true, Tipo = "Mecanico" });
            var controller = new AuthController(authMock.Object, mock.Object);
            var result = controller.Login("angel", "angel") as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);

        }
        [Test]
        public void TestLoginSuccess02()
        {
            var mock = new Mock<IAuthRepository>();
            var authMock = new Mock<IAuthService>();
            mock.Setup(o => o.Login("piero", "piero")).Returns(new Account() { Estado = true, Tipo = "Admin" });
            var controller = new AuthController(authMock.Object, mock.Object);
            var result = controller.Login("piero", "piero") as RedirectToActionResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);

        }
        [Test]
        public void TestLoginFail01()
        {
            var mock = new Mock<IAuthRepository>();
            var authMock = new Mock<IAuthService>();
            mock.Setup(o => o.Login("piero", "piero")).Returns((Account)null);
            var controller = new AuthController(authMock.Object, mock.Object);
            var result = controller.Login("pie", "piero123") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);

        }
        [Test]
        public void TestLoginFail02()
        {
            var mock = new Mock<IAuthRepository>();
            var authMock = new Mock<IAuthService>();
            mock.Setup(o => o.Login("angel", "angel")).Returns(new Account() { Estado = false });
            var controller = new AuthController(null, mock.Object);
            var result = controller.Login("angel", "angel") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);

        }
    }
}
