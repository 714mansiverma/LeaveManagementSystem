using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Models;
using EmployeeDetails.Repository;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeDetails.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployee<Employee> employee1;
       // private readonly LeaveSystemContext _context;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeesController));
        
        public EmployeesController(IEmployee<Employee> employee)
        {
            employee1 = employee;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        {
            _log4net.Info("GetRequest() called with json input");
            return employee1.GetAllEmployee();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public Employee GetEmployee(string id)
        {
            return employee1.GetEmployee(id);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutEmployee(string id,[FromBody]Employee employee)
        {
            if (employee==null)
            {
                return BadRequest();
            }
            Employee _emp = employee1.GetEmployee(id);
            if(_emp==null)
            {
                return NotFound();
            }
            employee1.UpdateEmployee(_emp, employee);
            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            using (var scope = new TransactionScope())
            {
                employee1.AddEmployee(employee);
                scope.Complete();
                CreatedAtAction(nameof(GetEmployee), new { id = employee.EmpId }, employee);
                return Ok();
            }
        }
        /*
        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
     */
    }
}
