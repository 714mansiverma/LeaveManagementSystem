using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Models;
using Authorization.Repository;
namespace Authorization.Repository
{
    public class AuthRepo : IEmployeeRepo<AuthorizationTable>
    {
        LeaveSystemContext _context;
        public AuthRepo(LeaveSystemContext context)
        {
            _context = context;

        }
        public void Add(AuthorizationTable details)
        {
            throw new NotImplementedException();
        }

        public void Deletet(string id)
        {
            throw new NotImplementedException();
        }

        public AuthorizationTable Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorizationTable> GetAll()
        {
            return _context.AuthorizationTable.ToList();

        }
    }
}
