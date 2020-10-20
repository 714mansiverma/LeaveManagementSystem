using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManager.Models;
using LeaveManager.Repository;
using System.Transactions;

namespace LeaveManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveServicesController : ControllerBase
    {
        ILeave<LeaveService> Leave1;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LeaveServicesController));
        public LeaveServicesController(ILeave<LeaveService> leave)
        {
            Leave1 = leave;
        }

        // GET: api/LeaveServices
        [HttpGet]
        public IEnumerable<LeaveService> GetLeaveService()
        {
            _log4net.Info("GetRequest() called with json input");
            return Leave1.GetAllLeave();
        }

        // GET: api/LeaveServices/5
        [HttpGet("{id}")]
        public LeaveService GetLeaveService(string id)
        {
            return Leave1.GetLeave(id);
        }

        // PUT: api/LeaveServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult PutLeaveService(string id,[FromBody] LeaveService leaveService)
        {
            if (leaveService == null)
            {
                return BadRequest();
            }
            LeaveService _leav = Leave1.GetLeave(id);
            if (_leav == null)
            {
                return NotFound();
            }
            Leave1.UpdateEmployee(_leav, leaveService);
            return NoContent();

        }

        // POST: api/LeaveServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostLeaveService(LeaveService leaveService)
        {
            using (var scope = new TransactionScope())
            {
                Leave1.ApplyLeave(leaveService);
                scope.Complete();
                CreatedAtAction(nameof(GetLeaveService), new { id = leaveService.EmpId }, leaveService);
                return Ok();
            }
        }
        /*

        // DELETE: api/LeaveServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveService>> DeleteLeaveService(string id)
        {
            var leaveService = await _context.LeaveService.FindAsync(id);
            if (leaveService == null)
            {
                return NotFound();
            }

            _context.LeaveService.Remove(leaveService);
            await _context.SaveChangesAsync();

            return leaveService;
        }

        private bool LeaveServiceExists(string id)
        {
            return _context.LeaveService.Any(e => e.EmpId == id);
        }
        */
    }
}
