using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RIBM.WebApi.Models;
using RIBM.WebApi.ViewModels;

namespace RIBM.WebApi.Controllers.Masters
{
    [Produces("application/json")]
    [Route("api/Machines")]
    public class MachinesController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public MachinesController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/Machines
        [HttpGet]
        public IEnumerable<MachineViewModel> GetMachine()
        {
            var machines = _context.Machine.Select(m => new MachineViewModel()
            {
                Id = m.Id,
                MachineTypeId = m.MachineTypeId,
                Code = m.Code,
                Descrip = m.Descrip,
                Model = m.Model,
                MachineSerialNo = m.MachineSerialNo,
                ManufactureYear = m.ManufactureYear,
                EngineSerialNumber = m.EngineSerialNumber,
                EngineMotorNumber = m.EngineMotorNumber,
                TyreNumber = m.TyreNumber,
                StarterMotarTeeth = m.StarterMotarTeeth,
                HeadgasKitNotch = m.HeadgasKitNotch,
                DieselFilterNumber = m.DieselFilterNumber,
                OilFilterNumber = m.OilFilterNumber,
                HydrolicFilterNumber = m.HydrolicFilterNumber,
                AirFilterNumber = m.AirFilterNumber,
                InsuranceDetails = m.InsuranceDetails,
                InsuranceStartDate = m.InsuranceStartDate,
                InsuranceEndDate = m.InsuranceEndDate,
                IsActive = m.IsActive,
                EntryUserId = m.EntryUserId,
                EntryDate = m.EntryDate,
                UpdateUserId = m.UpdateUserId,
                UpdateDate = m.UpdateDate,
                MachineTypeName = _context.MachineType.SingleOrDefault(mt => mt.Id == m.MachineTypeId).MachineTypeName
            }).ToList();

            return machines;
        }

        // GET: api/Machines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _context.Machine.SingleOrDefaultAsync(m => m.Id == id);

            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        // PUT: api/Machines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine([FromRoute] int id, [FromBody] Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machine.Id)
            {
                return BadRequest();
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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

        // POST: api/Machines
        [HttpPost]
        public async Task<IActionResult> PostMachine([FromBody] Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Machine.Add(machine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachine", new { id = machine.Id }, machine);
        }

        // DELETE: api/Machines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _context.Machine.SingleOrDefaultAsync(m => m.Id == id);
            if (machine == null)
            {
                return NotFound();
            }

            _context.Machine.Remove(machine);
            await _context.SaveChangesAsync();

            return Ok(machine);
        }

        private bool MachineExists(int id)
        {
            return _context.Machine.Any(e => e.Id == id);
        }
    }
}