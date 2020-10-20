using NUnit.Framework;
using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EmployeeDetails.Repository;
using EmployeeDetails.Controllers;
using EmployeeDetails.Models;
namespace UnitTest2
{
    [TestFixture]
    public class Tests
    {
        private Mock<IEmployee<Employee>> _employee;
        private EmployeesController _controller;
        [SetUp]
        public void Setup()
        {
            _employee = new Mock<IEmployee<Employee>>();
            _controller = new EmployeesController(_employee.Object);
        }

        [Test]
        public void Get_WhenCalled_ResturnsListOfEmployee()
        {

            _employee.Setup(repo => repo.GetAllEmployee()).Returns(new List<Employee> { new Employee()
            {
                EmpId="23",
                EmpName="mansi",
                Designation="abc",
                Department="cs",
                Age=23
            } });
            var result = _controller.GetEmployee();
            Assert.That(result.Count, Is.EqualTo(1));
        }
       
        [Test]
        public void Post_WhenCalled_ReturnsOk()
        {
            _employee.Setup(repo => repo.AddEmployee(It.IsAny<Employee>())).Verifiable();
            var result = _controller.PostEmployee(new Employee { });
            Assert.That(result, Is.TypeOf<OkResult>());

        }
    }
}