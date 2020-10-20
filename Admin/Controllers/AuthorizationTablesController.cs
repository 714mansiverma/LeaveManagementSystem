using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Admin.Models;
using Admin.Repository;
using System.Transactions;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationTablesController : ControllerBase
    {
        
        
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthorizationTablesController));
        IAdmin<AuthorizationTable> _admin1;
        public AuthorizationTablesController(IAdmin<AuthorizationTable> admin1)
        {
            _admin1 = admin1;
        }

        // GET: api/AuthorizationTables
        [HttpGet]
        public IEnumerable<AuthorizationTable> GetAuthorizationTable()
        {
            _log4net.Info("GetRequest() called with json input");
            return _admin1.GetUserName();
        }

        // GET: api/AuthorizationTables/5
        [HttpGet("{id}")]
        public AuthorizationTable GetAuthorizationTable(string id)
        {
            return _admin1.GetById(id);
        }
        /*

        // PUT: api/AuthorizationTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorizationTable(string id, AuthorizationTable authorizationTable)
        {
            if (id != authorizationTable.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(authorizationTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorizationTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        */
        // POST: api/AuthorizationTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostAuthorizationTable(AuthorizationTable authorizationTable)
        {
            using(var scope=new TransactionScope())
            {
                _admin1.AddDetail(authorizationTable);
                scope.Complete();
                 CreatedAtAction(nameof(GetAuthorizationTable), new { id = authorizationTable.EmpId }, authorizationTable);
                return Ok(); 
            }
            

            
        }
        /*
        // DELETE: api/AuthorizationTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorizationTable>> DeleteAuthorizationTable(string id)
        {
            var authorizationTable = await _context.AuthorizationTable.FindAsync(id);
            if (authorizationTable == null)
            {
                return NotFound();
            }

            _context.AuthorizationTable.Remove(authorizationTable);
            await _context.SaveChangesAsync();

            return authorizationTable;
        }

        private bool AuthorizationTableExists(string id)
        {
            return _context.AuthorizationTable.Any(e => e.EmpId == id);
        }*/
    }
}
