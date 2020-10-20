using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using EmployeeDetails.Controllers;


namespace EmployeeDetails.Repository
{
    public class EmployeeRepo : IEmployee<Employee>
    {
        LeaveSystemContext _context;
        public EmployeeRepo(LeaveSystemContext context)
        {
            _context = context;

        }
        public void AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployee(string id)
        {
            return _context.Employee.Find(id);
        }

        public void UpdateEmployee(Employee emp,Employee employee)
        {
            emp.EmpId = employee.EmpId;
            emp.EmpName = employee.EmpName;
            emp.Designation = employee.Designation;
            emp.Department = employee.Department;
            emp.Age = employee.Age;
            _context.SaveChangesAsync();
        }
    }
}
