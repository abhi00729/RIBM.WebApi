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
    [Route("api/ClientLocations")]
    public class ClientLocationsController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public ClientLocationsController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/ClientLocations
        [HttpGet]
        public IEnumerable<ClientLocation> GetClientLocation()
        {
            return _context.ClientLocation;
        }

        // GET: api/ClientLocations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineAssignment = await _context.MachineAssignment.Where(ma => ma.ClientId == id).ToListAsync();

            var clientLocation = await _context.ClientLocation.Where(m => m.ClientId == id).Select(cl => new
            {
                Id = cl.Id,
                ClientId = cl.ClientId,
                ContactPersonName = cl.ContactPersonName,
                MobileNo = cl.MobileNo,
                EmailAddress = cl.EmailAddress,
                Address = cl.Address,
                StateId = cl.StateId,
                CityId = cl.CityId,
                PinCode = cl.PinCode,
                IsPrimary = cl.IsPrimary,
                IsBillingAddress = cl.IsBillingAddress,
                IsActive = cl.IsActive,
                EntryUserId = cl.EntryUserId,
                EntryDate = cl.EntryDate,
                UpdateUserId = cl.UpdateUserId,
                UpdateDate = cl.UpdateDate,
                CityName = _context.City.Where(c => c.Id == cl.StateId).FirstOrDefault().CityName,
                StateName = _context.State.Where(s => s.Id == cl.StateId).FirstOrDefault().StateName,
                MachineAssignment = machineAssignment
            }).SingleOrDefaultAsync();

            if (clientLocation == null)
            {
                return NotFound();
            }

            return Ok(clientLocation);
        }

        // PUT: api/ClientLocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientLocation([FromRoute] int id, [FromBody] ClientLocation clientLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientLocationExists(id))
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

        // POST: api/ClientLocations
        [HttpPost]
        public async Task<IActionResult> PostClientLocation([FromBody] ClientLocation clientLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ClientLocation.Add(clientLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientLocation", new { id = clientLocation.Id }, clientLocation);
        }

        // DELETE: api/ClientLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientLocation = await _context.ClientLocation.SingleOrDefaultAsync(m => m.Id == id);
            if (clientLocation == null)
            {
                return NotFound();
            }

            _context.ClientLocation.Remove(clientLocation);
            await _context.SaveChangesAsync();

            return Ok(clientLocation);
        }

        private bool ClientLocationExists(int id)
        {
            return _context.ClientLocation.Any(e => e.Id == id);
        }
    }
}