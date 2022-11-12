using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainProject.Models;

namespace MainProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReimbursementDataController : ControllerBase
    {
        private readonly MainProjectContext _context;

        public ReimbursementDataController(MainProjectContext context)
        {
            _context = context;
        }

        // GET: api/ReimbursementData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReimbursementData>>> GetReimbursementDatas()
        {
            return await _context.ReimbursementDatas.ToListAsync();
        }

        // GET: api/ReimbursementData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReimbursementData>> GetReimbursementData(int id)
        {
            var reimbursementData = await _context.ReimbursementDatas.FindAsync(id);

            if (reimbursementData == null)
            {
                return NotFound();
            }

            return reimbursementData;
        }

        // PUT: api/ReimbursementData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReimbursementData(int id, ReimbursementData reimbursementData)
        {
            if (id != reimbursementData.ReimbursementID)
            {
                return BadRequest();
            }

            _context.Entry(reimbursementData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReimbursementDataExists(id))
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

        // POST: api/ReimbursementData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReimbursementData>> PostReimbursementData(ReimbursementData reimbursementData)
        {
            _context.ReimbursementDatas.Add(reimbursementData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReimbursementData", new { id = reimbursementData.ReimbursementID }, reimbursementData);
        }

        // DELETE: api/ReimbursementData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReimbursementData(int id)
        {
            var reimbursementData = await _context.ReimbursementDatas.FindAsync(id);
            if (reimbursementData == null)
            {
                return NotFound();
            }

            _context.ReimbursementDatas.Remove(reimbursementData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReimbursementDataExists(int id)
        {
            return _context.ReimbursementDatas.Any(e => e.ReimbursementID == id);
        }
    }
}
