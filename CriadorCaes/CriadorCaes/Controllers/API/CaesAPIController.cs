using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CriadorCaes.Data;
using CriadorCaes.Models;

namespace CriadorCaes.Controllers.API {

   [Route("api/[controller]")]
   [ApiController]
   public class CaesAPIController : ControllerBase {

      private readonly CriadorCaesBD _context;

      public CaesAPIController(CriadorCaesBD context) {
         _context = context;
      }

      // GET: api/CaesAPI
      [HttpGet]
      public async Task<ActionResult<IEnumerable<ListaCaesApiViewModel>>> GetCaes() {

         var listaCaes = await _context.Caes
                                       .Select(c => new ListaCaesApiViewModel {
                                          IdCao = c.Id,
                                          NomeCao = c.Nome
                                       })
                                       .OrderBy(c => c.NomeCao)
                                       .ToListAsync();

         return listaCaes;
      }

      // GET: api/CaesAPI/5
      [HttpGet("{id}")]
      public async Task<ActionResult<Caes>> GetCaes(int id) {
         var caes = await _context.Caes.FindAsync(id);

         if (caes == null) {
            return NotFound();
         }

         return caes;
      }

      // PUT: api/CaesAPI/5
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPut("{id}")]
      public async Task<IActionResult> PutCaes(int id, Caes caes) {
         if (id != caes.Id) {
            return BadRequest();
         }

         _context.Entry(caes).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException) {
            if (!CaesExists(id)) {
               return NotFound();
            }
            else {
               throw;
            }
         }

         return NoContent();
      }

      // POST: api/CaesAPI
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost]
      public async Task<ActionResult<Caes>> PostCaes(Caes caes) {
         _context.Caes.Add(caes);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetCaes", new { id = caes.Id }, caes);
      }

      // DELETE: api/CaesAPI/5
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteCaes(int id) {
         var caes = await _context.Caes.FindAsync(id);
         if (caes == null) {
            return NotFound();
         }

         _context.Caes.Remove(caes);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool CaesExists(int id) {
         return _context.Caes.Any(e => e.Id == id);
      }
   }
}
