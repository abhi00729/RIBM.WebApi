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
    [Route("api/MachineTypes")]
    public class MachineTypesController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public MachineTypesController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/MachineTypes
        [HttpGet]
        public IEnumerable<MachineType> GetMachineType()
        {
            return _context.MachineType;
        }

        // GET: api/MachineTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachineType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineType = await _context.MachineType.SingleOrDefaultAsync(m => m.Id == id);

            if (machineType == null)
            {
                return NotFound();
            }

            return Ok(machineType);
        }

        // PUT: api/MachineTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachineType([FromRoute] int id, [FromBody] MachineType machineType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machineType.Id)
            {
                return BadRequest();
            }

            _context.Entry(machineType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineTypeExists(id))
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

        // POST: api/MachineTypes
        [HttpPost]
        public async Task<IActionResult> PostMachineType([FromBody] MachineType machineType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MachineType.Add(machineType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachineType", new { id = machineType.Id }, machineType);
        }

        // DELETE: api/MachineTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachineType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineType = await _context.MachineType.SingleOrDefaultAsync(m => m.Id == id);
            if (machineType == null)
            {
                return NotFound();
            }

            _context.MachineType.Remove(machineType);
            await _context.SaveChangesAsync();

            return Ok(machineType);
        }

        private bool MachineTypeExists(int id)
        {
            return _context.MachineType.Any(e => e.Id == id);
        }
    }
}