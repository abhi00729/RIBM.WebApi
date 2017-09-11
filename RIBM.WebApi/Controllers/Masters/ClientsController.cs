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
    [Route("api/Clients")]
    public class ClientsController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public ClientsController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> GetClient()
        {
            return _context.Client;
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var clientLocations = await _context.ClientLocation.Where(m => m.ClientId == id).Select(cl => new ClientLocationViewModel
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
                CityName = _context.City.Where(c => c.Id == cl.CityId).FirstOrDefault().CityName,
                StateName = _context.State.Where(s => s.Id == cl.StateId).FirstOrDefault().StateName
            }).ToListAsync();

            var machineAssignments = await _context.MachineAssignment.Where(ma => ma.ClientId == id).ToListAsync();
            
            var client = await _context.Client.Where(c => c.Id == id).Select(c => new ClientViewModel
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                FirstName = c.FirstName,
                LastName = c.LastName,
                MobileNo = c.MobileNo,
                EmailAddress = c.EmailAddress,
                IsActive = c.IsActive,
                EntryUserId = c.EntryUserId,
                EntryDate = c.EntryDate,
                UpdateUserId = c.UpdateUserId,
                UpdateDate = c.UpdateDate,
                ClientLocation = clientLocations,
                MachineAssignment = machineAssignments
            }).SingleOrDefaultAsync();

            if (client == null)
            {
                return NotFound();
            }
            
            return Ok(client);
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient([FromRoute] int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _context.Client.SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}