using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.Repository
{
     public  interface ILeave<T>
    {
        void ApplyLeave(T employee);
        void UpdateEmployee(T employeeLeave, T employeeLeave1);
        T GetLeave(string id);
        IEnumerable<T> GetAllLeave();
    }
}
