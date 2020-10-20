using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Models;

namespace Authorization.Repository
{
    public interface IEmployeeRepo<T>
    {
        void Add(T details);
        void Deletet(string id);
        T Get(string id);
        IEnumerable<T> GetAll();
    }
    
}
