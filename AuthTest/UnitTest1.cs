using NUnit.Framework;
using Authorization;
using Authorization.Models;
using Authorization.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
//using AuthTest.Repository;
//using Authorization.Models;
using Authorization.Controllers;

namespace AuthTest
{
    public class AuthTest
    {
        private Mock<IEmployeeRepo<AuthorizationTable>> _user;
        private Mock<IConfiguration> _config;
        private Mock<IAuth> _auth1;
        private AuthController _controller;

        [SetUp]
        public void Setup()
        {
            _config = new Mock<IConfiguration>();
            _user = new Mock<IEmployeeRepo<AuthorizationTable>>();
            _auth1 = new Mock<IAuth>();
           _controller = new AuthController(_config.Object, _user.Object, _auth1.Object);

        }

        [Test]
        public void Login_WhenCalled_ReturnsOk()
        {
            AuthorizationTable table = new AuthorizationTable()
            {
                UserName="mansi",
                Pswd="mansi",
                EmpId="1"
            };
            _auth1.Setup(r => r.AuthenticateUser(It.IsAny<AuthorizationTable>())).Returns(table);
            _auth1.Setup(r => r.GenerateJSONWebToken()).Returns("token");
            var result = _controller.Login(table);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());

        }
        [Test]
        public void Login_WhenCalled_Unauthorized()
        {
            AuthorizationTable authorizationTable = new AuthorizationTable()
            {
                EmpId = "202",
                UserName = "klj",
                Pswd = "1234"
            };
            _auth1.Setup(r => r.AuthenticateUser(It.IsAny<AuthorizationTable>())).Returns(() => null);
            _auth1.Setup(r => r.GenerateJSONWebToken()).Returns("Token");
            var result = _controller.Login(authorizationTable);
            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }
    }
}