using NUnit.Framework;
using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;
using Moq;
using Microsoft.AspNetCore.Mvc;
using LeaveManager.Repository;
using LeaveManager.Controllers;
using LeaveManager.Models;
namespace LeaveUnitTest
{
    [TestFixture]
    public class Tests
    {
        private Mock<ILeave<LeaveService>> _leave;
        private LeaveServicesController _controller;
        [SetUp]
        public void Setup()
        {
            _leave = new Mock<ILeave<LeaveService>>();
            _controller = new LeaveServicesController(_leave.Object);
        }

        [Test]
        public void Get_WhenCalled_ResturnsListOfEmployee()
        {

            _leave.Setup(repo => repo.GetAllLeave()).Returns(new List<LeaveService> { new LeaveService()
            {
                EmpId="1",
                NoOfDaysLeave=2,
                EmpName="jkh",
                Status="applied"
            } });
            var result = _controller.GetLeaveService();
            Assert.That(result.Count, Is.EqualTo(1));
        }
        [Test]
        public void Post_WhenCalled_ReturnsOk()
        {
            _leave.Setup(repo => repo.ApplyLeave(It.IsAny<LeaveService>())).Verifiable();
            var result = _controller.PostLeaveService(new LeaveService { });
            Assert.That(result, Is.TypeOf<OkResult>());

        }
    }
}