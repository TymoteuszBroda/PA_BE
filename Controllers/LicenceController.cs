using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermAdminAPI.Data;
using PermAdminAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenceController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Licence>>> GetLicences()
        {
            var licences = await context.Licences.ToListAsync();
            return Ok(licences);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Licence>> GetLicence(int id)
        {
            var licence = await context.Licences.FindAsync(id);
            if (licence == null) return NotFound();
            return Ok(licence);
        }

        [HttpPost]
        public async Task<ActionResult<Licence>> CreateLicence(Licence licence)
        {
            context.Licences.Add(licence);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLicence), new { id = licence.id }, licence);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLicence(int id, Licence licence)
        {
            if (id != licence.id) return BadRequest();

            context.Entry(licence).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenceExists(id)) return NotFound();
                throw;
            }
            return NoContent();
        }
        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<Licence>>> CreateLicences(List<Licence> licences)
        {
            context.Licences.AddRange(licences);
            await context.SaveChangesAsync();
            return Ok(licences);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicence(int id)
        {
            var licence = await context.Licences.FindAsync(id);
            if (licence == null) return NotFound();

            context.Licences.Remove(licence);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool LicenceExists(int id)
        {
            return context.Licences.Any(e => e.id == id);
        }
    }
}
