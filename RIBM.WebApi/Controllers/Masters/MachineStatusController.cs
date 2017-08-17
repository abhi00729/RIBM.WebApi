using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RIBM.WebApi.Models;

namespace RIBM.WebApi.Controllers.Masters
{
    [Produces("application/json")]
    [Route("api/MachineStatus")]
    public class MachineStatusController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public MachineStatusController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/MachineStatus
        [HttpGet]
        public IEnumerable<MachineStatus> GetMachineStatus()
        {
            return _context.MachineStatus;
        }

        // GET: api/MachineStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachineStatus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineStatus = await _context.MachineStatus.SingleOrDefaultAsync(m => m.Id == id);

            if (machineStatus == null)
            {
                return NotFound();
            }

            return Ok(machineStatus);
        }

        // PUT: api/MachineStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachineStatus([FromRoute] int id, [FromBody] MachineStatus machineStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machineStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(machineStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineStatusExists(id))
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

        // POST: api/MachineStatus
        [HttpPost]
        public async Task<IActionResult> PostMachineStatus([FromBody] MachineStatus machineStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MachineStatus.Add(machineStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachineStatus", new { id = machineStatus.Id }, machineStatus);
        }

        // DELETE: api/MachineStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachineStatus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineStatus = await _context.MachineStatus.SingleOrDefaultAsync(m => m.Id == id);
            if (machineStatus == null)
            {
                return NotFound();
            }

            _context.MachineStatus.Remove(machineStatus);
            await _context.SaveChangesAsync();

            return Ok(machineStatus);
        }

        private bool MachineStatusExists(int id)
        {
            return _context.MachineStatus.Any(e => e.Id == id);
        }
    }
}