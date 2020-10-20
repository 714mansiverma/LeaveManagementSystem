using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManager.Repository;
using LeaveManager.Models;
using System.Net.Http;

namespace LeaveManager.Repository
{
    public class LeaveRepo : ILeave<LeaveService>
    {
        LeaveSystemContext _context;
        public LeaveRepo(LeaveSystemContext context)
        {
            _context = context;

        }
        public void ApplyLeave(LeaveService employee)
        {
            _context.LeaveService.Add(employee);
            _context.SaveChangesAsync();
        }

        public IEnumerable<LeaveService> GetAllLeave()
        {
            return _context.LeaveService.ToList();
        }

        public LeaveService GetLeave(string id)
        {
            return _context.LeaveService.Find(id);
        }

        public void UpdateEmployee(LeaveService employeeLeave, LeaveService employeeLeave1)
        {
            employeeLeave.EmpId = employeeLeave1.EmpId;
            employeeLeave.EmpName = employeeLeave1.EmpName;
            employeeLeave.NoOfDaysLeave = employeeLeave1.NoOfDaysLeave;
            employeeLeave.Status = employeeLeave1.Status;
           _context.SaveChangesAsync();
        }
    }
}
