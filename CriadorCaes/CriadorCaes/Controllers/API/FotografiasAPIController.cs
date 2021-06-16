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



   // definir a rota de acesso a este controller
   [Route("api/[controller]")]
   // estamos a assinalar que este controller é de uma API 
   [ApiController]
   public class FotografiasAPIController : ControllerBase {

      private readonly CriadorCaesBD _context;

      public FotografiasAPIController(CriadorCaesBD context) {
         _context = context;
      }


      /// <summary>
      /// método para listar os dados dos diversos cães existentes na base de dados.
      /// Só é acedido quando o pedido HTTP é efetuado em GET
      /// </summary>
      /// <returns></returns>
      [HttpGet]
      public async Task<ActionResult<IEnumerable<ListaFotosApiViewModel>>> GetFotografias() {


         var listaFotos = await _context.Fotografias
                                      .Include(f => f.Cao)
                                      .Select(f => new ListaFotosApiViewModel {
                                         IdFoto = f.Id,
                                         NomeFoto = f.Fotografia,
                                         DataFoto = f.DataFoto.ToShortDateString(),
                                         LocalFoto = f.Local,
                                         NomeCao = f.Cao.Nome
                                      })
                                      .OrderBy(f => f.NomeCao)
                                      .ToListAsync();

         return listaFotos;
      }



      /// <summary>
      /// método igual ao que está acima.
      /// Apenas é acedido em modo GET.
      /// Lista apenas os dados da Fotografia, cujo ID é fornecido
      /// </summary>
      /// <param name="id">identificador (PK) da Foto a apresentar</param>
      /// <returns></returns>
      [HttpGet("{id}")]
      public async Task<ActionResult<ListaFotosApiViewModel>> GetFotografias(int id) {

         var fotografia = await _context.Fotografias
                                        .Where(f => f.Id == id)
                                        .Select(f => new ListaFotosApiViewModel {
                                           IdFoto = f.Id,
                                           LocalFoto = f.Local,
                                           DataFoto = f.DataFoto.ToShortDateString(),
                                           NomeFoto = f.Fotografia,
                                           NomeCao = f.Cao.Nome
                                        })
                                        .FirstOrDefaultAsync();

         if (fotografia == null) {
            return NotFound();
         }

         return fotografia;
      }



      // PUT: api/FotografiasAPI/5
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPut("{id}")]
      public async Task<IActionResult> PutFotografias(int id, Fotografias fotografias) {
         if (id != fotografias.Id) {
            return BadRequest();
         }

         _context.Entry(fotografias).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException) {
            if (!FotografiasExists(id)) {
               return NotFound();
            }
            else {
               throw;
            }
         }

         return NoContent();
      }



      /// <summary>
      /// Método para guardar na base de dados os dados de uma nova Fotografia.
      /// Apenas pode ser acedido se o HTTP estiver a usar o POST
      /// </summary>
      /// <param name="fotografia">dados da nova fotografia</param>
      /// <returns></returns>
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost]
      public async Task<ActionResult<Fotografias>> PostFotografias([FromForm] Fotografias fotografia, IFormFile UploadFotografia) {

         /* - o anotador [FromForm] instrui a ASP .NET Core a aceitar os dados vindos do formulário do React
         *   e associá-los ao objeto interno 'fotografia'
         * 
         * - o atributo UploadFotografia terá um tratamento 100% igual ao que foi feito no controller das Fotografias
         */

         // *********************************************************************
         // esta instrução é apenas usada para não se criar uma exceção no código
         // deverá ser apagada quando se concretizar o trabalho real
         fotografia.Fotografia = "";
         // *********************************************************************

         _context.Fotografias.Add(fotografia);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetFotografias", new { id = fotografia.Id }, fotografia);
      }




      // DELETE: api/FotografiasAPI/5
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteFotografias(int id) {
         var fotografias = await _context.Fotografias.FindAsync(id);
         if (fotografias == null) {
            return NotFound();
         }

         _context.Fotografias.Remove(fotografias);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool FotografiasExists(int id) {
         return _context.Fotografias.Any(e => e.Id == id);
      }
   }
}
