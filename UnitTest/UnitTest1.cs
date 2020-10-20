using NUnit.Framework;
using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;
using Moq;
using Microsoft.AspNetCore.Mvc;

using Admin.Repository;
using Admin.Controllers;
using Admin.Models;

namespace UnitTest
{
    [TestFixture]
    public class Tests
    {
        private Mock<IAdmin<AuthorizationTable>> _admin;
        private AuthorizationTablesController _controller;
        [SetUp]
        public void Setup()
        {
            _admin = new Mock<IAdmin<AuthorizationTable>>();
            _controller = new AuthorizationTablesController(_admin.Object);
        }

        [Test]
        public void Get_WhenCalled_ResturnsListOfAuthorizationTable()
        {
            _admin.Setup(repo => repo.GetUserName()).Returns(new List<AuthorizationTable> { new AuthorizationTable()
            {
                EmpId="178",
                UserName="mansiverma",
                Pswd="mansiverma"
            } });
            var result = _controller.GetAuthorizationTable();
            Assert.That(result.Count, Is.EqualTo(1));
        }
        [Test]
        public void Post_WhenCalled_ReturnsOk()
        {
            _admin.Setup(repo => repo.AddDetail(It.IsAny<AuthorizationTable>())).Verifiable();
            var result = _controller.PostAuthorizationTable(new AuthorizationTable { });
            Assert.That(result, Is.TypeOf<OkResult>());

        }
    }
}