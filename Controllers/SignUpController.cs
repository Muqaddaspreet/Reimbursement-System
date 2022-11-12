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
    public class SignUpController : ControllerBase
    {
        private readonly MainProjectContext _context;

        public SignUpController(MainProjectContext context)
        {
            _context = context;
        }

        // GET: api/SignUp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignUp>>> GetSignUps()
        {
            return await _context.SignUps.ToListAsync();
        }

        // GET: api/SignUp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SignUp>> GetSignUp(int id)
        {
            var signUp = await _context.SignUps.FindAsync(id);

            if (signUp == null)
            {
                return NotFound();
            }

            return signUp;
        }

        // PUT: api/SignUp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignUp(int id, SignUp signUp)
        {
            if (id != signUp.SignUpID)
            {
                return BadRequest();
            }

            _context.Entry(signUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignUpExists(id))
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

        // POST: api/SignUp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SignUp>> PostSignUp(SignUp signUp)
        {
            _context.SignUps.Add(signUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignUp", new { id = signUp.SignUpID }, signUp);
        }

        // DELETE: api/SignUp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignUp(int id)
        {
            var signUp = await _context.SignUps.FindAsync(id);
            if (signUp == null)
            {
                return NotFound();
            }

            _context.SignUps.Remove(signUp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SignUpExists(int id)
        {
            return _context.SignUps.Any(e => e.SignUpID == id);
        }
    }
}
