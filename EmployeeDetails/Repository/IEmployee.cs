using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Repository
{
    public interface IEmployee<T>
    {
        void AddEmployee(T employee);
       void UpdateEmployee(T employee, T employee1);

        T GetEmployee(string id);
        IEnumerable<T> GetAllEmployee();
    }
}
