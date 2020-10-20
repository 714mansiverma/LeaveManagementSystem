using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using Admin.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Repository
{
    public class AdminRepo : IAdmin<AuthorizationTable>
    {
        LeaveSystemContext _context;
        public AdminRepo(LeaveSystemContext context)
        {
            _context = context; 

        }

        public void AddDetail(AuthorizationTable details)
        {
            _context.AuthorizationTable.Add(details);
            _context.SaveChangesAsync();
            
            
        }

        public AuthorizationTable GetById(string id)
        {
            return _context.AuthorizationTable.Find(id);
        }

        public IEnumerable<AuthorizationTable> GetUserName()
        {
            return _context.AuthorizationTable.ToList();

        }
    }
}
