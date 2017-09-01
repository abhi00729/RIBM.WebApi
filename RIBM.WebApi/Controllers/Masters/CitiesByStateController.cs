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
    [Route("api/CitiesByState")]
    public class CitiesByStateController : Controller
    {
        private readonly RIBusinessManagementContext _context;

        public CitiesByStateController(RIBusinessManagementContext context)
        {
            _context = context;
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cities = await _context.City.Where(m => m.StateId == id).ToListAsync();

            if (cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Id == id);
        }
    }
}