using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer.UseCases.LoginUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Services.Interfaces;

namespace ApplicationLayer.UseCases.LoginUC.Tests
{
    [TestClass()]
    public class LoginUCTests
    {
        [TestMethod()]
        public void LoginUCTest()
        {
            LoginUC loginUC = new LoginUC();
            var a = loginUC.Authenticate("admin", "admin");
            Assert.IsTrue(a);
        }

        [TestMethod()]
        public void LoginUCTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AuthenticateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTokenTest()
        {
            Assert.Fail();
        }
    }
}