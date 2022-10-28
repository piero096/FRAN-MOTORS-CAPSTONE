using FranMotors.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Controller
{
    class EmailValidatorTest
    {
        [Test]
        public void TestFormatoCorrectoEmail()
        {
            Assert.IsTrue(EmailValidator.ValidateEmail("a@b.c"));
            Assert.IsTrue(EmailValidator.ValidateEmail("test@dominio.com"));
            Assert.IsTrue(EmailValidator.ValidateEmail("test.con.puntos@dominio.com"));
            Assert.IsTrue(EmailValidator.ValidateEmail("abcdefghijklmnoprstuvwxyz.0123456789@dominio.test"));

        }
        [Test]
        public void TestFormatoIncorrectoEmail()
        {
            Assert.IsFalse(EmailValidator.ValidateEmail("esto no es un correo electronico"));
            Assert.IsFalse(EmailValidator.ValidateEmail("@b.c"));
            Assert.IsFalse(EmailValidator.ValidateEmail("test@dominio@com"));
            Assert.IsFalse(EmailValidator.ValidateEmail(".test@dominio@com"));
        }
    }
}
