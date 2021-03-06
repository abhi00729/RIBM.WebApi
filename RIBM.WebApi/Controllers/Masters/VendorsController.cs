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
    [Route("api/Vendors")]
    public class VendorsController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public VendorsController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/Vendors
        [HttpGet]
        public IEnumerable<VendorViewModel> GetVendor()
        {
            var vendors = _context.Vendor.Select(m => new VendorViewModel
            {
                Id = m.Id,
                CompanyName = m.CompanyName,
                FirstName = m.FirstName,
                LastName = m.LastName,
                MobileNo = m.MobileNo,
                EmailAddress = m.EmailAddress,
                Address = m.Address,
                StateId = m.StateId,
                CityId = m.CityId,
                PinCode = m.PinCode,
                IsActive = m.IsActive,
                EntryUserId = m.EntryUserId,
                EntryDate = m.EntryDate,
                UpdateUserId = m.UpdateUserId,
                UpdateDate = m.UpdateDate,
                CityName = _context.City.Where(c => c.Id == m.CityId).FirstOrDefault().CityName,
                StateName = _context.State.Where(s => s.Id == m.StateId).FirstOrDefault().StateName
            }).ToList();

            return vendors;
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _context.Vendor.SingleOrDefaultAsync(m => m.Id == id);

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        // PUT: api/Vendors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor([FromRoute] int id, [FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
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

        // POST: api/Vendors
        [HttpPost]
        public async Task<IActionResult> PostVendor([FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vendor.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _context.Vendor.SingleOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendor.Remove(vendor);
            await _context.SaveChangesAsync();

            return Ok(vendor);
        }

        private bool VendorExists(int id)
        {
            return _context.Vendor.Any(e => e.Id == id);
        }
    }
}