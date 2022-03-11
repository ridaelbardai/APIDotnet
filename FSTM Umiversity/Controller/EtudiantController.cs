using FSTM_Umiversity.Data;
using FSTM_Umiversity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace FSTM_Umiversity.Controller
{
    [Route("api/Etudiant")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class EtudiantsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public EtudiantsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Etudiants
        [HttpGet]
        public List<Student> GetEtudiants()
        {
            return _context.Students.ToList();
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetEtudiant(int id)
        {
            var etudiant = await _context.Students.FindAsync(id);

            if (etudiant == null)
            {
                return null;
            }

            return etudiant;
        }

        // PUT: api/Etudiants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiant(int id, Student etudiant)
        {
            if (id != etudiant.ID)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
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

        // POST: api/Etudiants

        [HttpPost]
        public async Task<ActionResult<Student>> PostEtudiant(Student etudiant)
        {
            _context.Students.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.ID }, etudiant);
        }

        // DELETE: api/Etudiants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(int id)
        {
            var etudiant = await _context.Students.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.Students.Remove(etudiant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtudiantExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
