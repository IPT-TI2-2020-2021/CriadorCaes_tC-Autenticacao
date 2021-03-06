using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CriadorCaes.Data;
using CriadorCaes.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CriadorCaes.Controllers {

   /// <summary>
   /// controller para efetuar a gestão das fotografias dos cães
   /// </summary>

   [Authorize]  // este anotador impede o acesso ao objeto protegido
                // se o utilizador não estiver autenticado
   public class FotografiasController : Controller {

      /// <summary>
      /// atributo que referencia a Base de Dados do projeto
      /// </summary>
      private readonly CriadorCaesBD _db;

      /// <summary>
      /// Atributo que guarda nele os dados do Servidor
      /// </summary>
      private readonly IWebHostEnvironment _dadosServidor;

      /// <summary>
      /// Atributo que irá receber todos os dados referentes à
      /// pessoa q se autenticou no sistema
      /// </summary>
      private readonly UserManager<IdentityUser> _userManager;

      public FotografiasController(
         CriadorCaesBD context,
         IWebHostEnvironment dadosServidor,
         UserManager<IdentityUser> userManager) {
         _db = context;
         _dadosServidor = dadosServidor;
         _userManager = userManager;
      }

      // GET: Fotografias
      /// <summary>
      /// lista as fotos dos cães
      /// </summary>
      /// <returns></returns>

      [AllowAnonymous] // esta anotação anula o efeito do [Authorize]
      public async Task<IActionResult> Index() {

         /* o comando seguinte é equivalente
          * SELECT *
          * FROM Fotografia f, Caes c
          * WHERE f.caoFK = c.id
          */
         var listaFotosCaes = await _db.Fotografias.Include(f => f.Cao)
                                                  .OrderByDescending(f => f.DataFoto)  // LINQ
                                                  .ToListAsync();
         // var. auxiliar
         string username = _userManager.GetUserId(User);

         // quais o(s) cão/cães da pessoa q se autenticou?
         var listaCaes = await (from c in _db.Caes
                                join cc in _db.CriadoresCaes on c.Id equals cc.CaoFK
                                join cr in _db.Criadores on cc.CriadorFK equals cr.Id
                                where cr.UserNameId == username
                                select c.Id)
                               .ToListAsync();

         // é uma opção, mas não a vamos usar...
         // ViewBag.caes = listaCaes;

         // vamos usar um 'ViewModel'
         // para o transporte
         var listaFotos = new ListarFotosViewModel {
            ListaFotos = listaFotosCaes,
            ListaCaes = listaCaes
         };

         // invocar a View, entregando-lhe os dados devolvidos pela BD
         // sendo transformados numa LISTA assíncrona
         return View(listaFotos);
      }






      // GET: Fotografias/Details/5
      public async Task<IActionResult> Details(int? id) {
         if (id == null) {
            return NotFound();
         }

         var fotografias = await _db.Fotografias
             .Include(f => f.Cao)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (fotografias == null) {
            return NotFound();
         }

         return View(fotografias);
      }

      // GET: Fotografias/Create
      public IActionResult Create() {

         //// prepara os dados a serem enviados para a View
         //// para a Dropdown
         //ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome");

         var listaCaes = (from c in _db.Caes
                          join cc in _db.CriadoresCaes on c.Id equals cc.CaoFK
                          join cr in _db.Criadores on cc.CriadorFK equals cr.Id
                          where cr.UserNameId == _userManager.GetUserId(User)
                          select c)
                         .OrderBy(c => c.Nome);

         ViewData["CaoFK"] = new SelectList(listaCaes, "Id", "Nome");


         return View();
      }

      // POST: Fotografias/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("DataFoto,Local,CaoFK")] Fotografias foto, IFormFile fotoCao) {

         /* Avaliar o q fazer com o ficheiro
          * 
          * existe ficheiro???
          *  - se não existe, devolve o controlo à View, 
          *                   notificando o utilizador que deve selecionar uma fotografia
          * 
          *  - se existe,
          *    - será que o ficheiro é do tipo correto (jpg, jpeg ou png)?
          *        - se sim, definir o nome do ficheiro
          *                  associar ao objeto 'foto' o nome do ficheiro
          *                  definir a localização
          *                  guardar o ficheiro no disco rígido
          *        - se não, devolve o controlo à View, 
          *                  notificando o utilizador que deve selecionar uma fotografia
          */

         // lista dos cães que pertencem à pessoa a q se autentica
         var listaCaes = (from c in _db.Caes
                          join cc in _db.CriadoresCaes on c.Id equals cc.CaoFK
                          join cr in _db.Criadores on cc.CriadorFK equals cr.Id
                          where cr.UserNameId == _userManager.GetUserId(User)
                          select c)
                         .OrderBy(c => c.Nome);

         // avaliar se existe ficheiro
         if (fotoCao == null) {
            // se aqui entro, não há foto
            // notificar o utilizador que há um erro
            ModelState.AddModelError("", "Deve selecionar uma fotografia...");

            // devolver o controlo à View
            // prepara os dados a serem enviados para a View
            // para a Dropdown
            // ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome");
            ViewData["CaoFK"] = new SelectList(listaCaes, "Id", "Nome");
            return View();
         }

         // há ficheiro. Mas, será do tipo correto (jpg/jpeg, png)?
         if (fotoCao.ContentType == "image/png" || fotoCao.ContentType == "image/jpeg") {
            // o ficheiro é bom

            // definir o nome do ficheiro
            string nomeFoto = "";
            Guid g;
            g = Guid.NewGuid();
            nomeFoto = foto.CaoFK + "_" + g.ToString();
            string extensaoFoto = Path.GetExtension(fotoCao.FileName).ToLower();
            nomeFoto = nomeFoto + extensaoFoto;

            // associar ao objeto 'foto' o nome do ficheiro
            foto.Fotografia = nomeFoto;
         }
         else {
            // se aqui chego, há ficheiro, mas não foto
            // se aqui entro, não há foto
            // notificar o utilizador que há um erro
            ModelState.AddModelError("", "Deve selecionar uma fotografia...");

            // devolver o controlo à View
            // prepara os dados a serem enviados para a View
            // para a Dropdown
            //  ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome");
            ViewData["CaoFK"] = new SelectList(listaCaes, "Id", "Nome");
            return View();
         }


         if (foto.CaoFK > 0) {
            try {
               if (ModelState.IsValid) {
                  // se o Estado do Modelo for válido 
                  // ie., se os dados do objeto 'foto' estiverem de acordo com as regras definidas
                  // no modelo (classe Fotografias)

                  // adicionar os dados da 'foto' à base de dados
                  _db.Add(foto);

                  // consolidar as alterações na base de dados
                  // COMMIT
                  await _db.SaveChangesAsync();

                  // vou guardar o ficheiro no disco rígido do servidor
                  // determinar onde guardar o ficheiro
                  string caminhoAteAoFichFoto = _dadosServidor.WebRootPath;
                  caminhoAteAoFichFoto = Path.Combine(caminhoAteAoFichFoto, "fotos", foto.Fotografia);
                  // guardar o ficheiro no Disco Rígido
                  using var stream = new FileStream(caminhoAteAoFichFoto, FileMode.Create);
                  await fotoCao.CopyToAsync(stream);

                  // redireciona a execução do código para a método Index    
                  return RedirectToAction(nameof(Index));
               }
            }
            catch (Exception) {
               ModelState.AddModelError("", "Ocorreu um erro com a introdução dos dados da Fotografia.");
            }
         }
         else {
            ModelState.AddModelError("", "Não se esqueça de escolher um cão...");
         }

         //     ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome", foto.CaoFK);
         ViewData["CaoFK"] = new SelectList(listaCaes, "Id", "Nome");

         return View(foto);
      }







      // GET: Fotografias/Edit/5
      public async Task<IActionResult> Edit(int? id) {
         if (id == null) {
            return NotFound();
         }

         var fotografias = await _db.Fotografias.FindAsync(id);
         if (fotografias == null) {
            return NotFound();
         }
         ViewData["CaoFK"] = new SelectList(_db.Caes.OrderBy(c => c.Nome), "Id", "Nome", fotografias.CaoFK);
         return View(fotografias);
      }

      // POST: Fotografias/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Fotografia,DataFoto,Local,CaoFK")] Fotografias fotografias) {
         if (id != fotografias.Id) {
            return NotFound();
         }

         if (ModelState.IsValid) {
            try {
               _db.Update(fotografias);
               await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
               if (!FotografiasExists(fotografias.Id)) {
                  return NotFound();
               }
               else {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         ViewData["CaoFK"] = new SelectList(_db.Caes, "Id", "Id", fotografias.CaoFK);
         return View(fotografias);
      }

      // GET: Fotografias/Delete/5
      public async Task<IActionResult> Delete(int? id) {
         if (id == null) {
            return NotFound();
         }

         var fotografia = await _db.Fotografias
             .Include(f => f.Cao)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (fotografia == null) {
            return NotFound();
         }

         // guardar o ID da foto escolhida, para memória futura
         // Session["idFoto"]= id;   --> deixou de estar disponível
         HttpContext.Session.SetInt32("idFoto", (int)id);

         return View(fotografia);
      }




      // POST: Fotografias/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id) {

         // ler o valor do ID que foi previamente guardado
         var numIdFoto = HttpContext.Session.GetInt32("idFoto");

         // confrontar este valor com o 'id' que agora é fornecido
         // se for diferente, é pq há um problema
         if (numIdFoto != id) {
            // há problema pq houve alteração de algo no browser
            // nada digo, e redireciono a app para uma página neutra
            return RedirectToAction("Index");
         }

         try {
            var fotografias = await _db.Fotografias.FindAsync(id);
            _db.Fotografias.Remove(fotografias);
            await _db.SaveChangesAsync();

            // se cheguei aqui,
            // não esquecer de eliminar o ficheiro

         }
         catch (Exception) {

            throw;
         }

         return RedirectToAction(nameof(Index));
      }






      // GET: Fotografias/Delete/5
      public async Task<IActionResult> DeleteDois(int? id) {
         if (id == null) {
            return NotFound();
         }

         var fotografia = await _db.Fotografias
             .Include(f => f.Cao)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (fotografia == null) {
            return NotFound();
         }

         // guardar o ID da foto escolhida, para memória futura
         // Session["idFoto"]= id;   --> deixou de estar disponível
         HttpContext.Session.SetInt32("idFoto", (int)id);

         return View(fotografia);
      }




      // POST: Fotografias/Delete/5
      [HttpPost, ActionName("DeleteDois")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteDoisConfirmed() {

         // ler o valor do ID que foi previamente guardado
         var numIdFoto = HttpContext.Session.GetInt32("idFoto");

         // se a var de sessão extinguir-se,
         // temos um problema
         if (numIdFoto == null) {
            //é preciso alertar o utilizador que demorou tempo de mais

            // e devolver o controlo à View
            return RedirectToAction("Index");
         }

         var fotografias = await _db.Fotografias.FindAsync(numIdFoto);
         _db.Fotografias.Remove(fotografias);
         await _db.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }



      private bool FotografiasExists(int id) {
         return _db.Fotografias.Any(e => e.Id == id);
      }
   }
}
