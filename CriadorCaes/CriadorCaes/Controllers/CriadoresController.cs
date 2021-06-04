using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CriadorCaes.Data;
using CriadorCaes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CriadorCaes.Controllers {

   [Authorize]
   public class CriadoresController : Controller {

      /// <summary>
      /// referência à Base de Dados
      /// </summary>
      private readonly CriadorCaesBD _db;

      /// <summary>
      /// objeto para gerir os dados dos Utilizadores registados
      /// </summary>
      private readonly UserManager<IdentityUser> _userManager;


      public CriadoresController(
         CriadorCaesBD context,
         UserManager<IdentityUser> userManager) {
         _db = context;
         _userManager = userManager;
      }

      // GET: Criadores
      public async Task<IActionResult> Index() {
         return View(await _db.Criadores.ToListAsync());
      }

      // GET: Criadores/Details/5
      public async Task<IActionResult> Details(int? id) {
         if (id == null) {
            return NotFound();
         }

         var criadores = await _db.Criadores
             .FirstOrDefaultAsync(m => m.Id == id);
         if (criadores == null) {
            return NotFound();
         }

         return View(criadores);
      }


      /// <summary>
      /// Apresenta a janela com a lista dos Utilizadores criados
      /// e não validados
      /// </summary>
      /// <returns></returns>
     [Authorize(Roles ="Gestor")]
      /*
       [Authorize(Roles = "Gestor")]           --> só users do tipo Gestor podem aceder
       [Authorize(Roles = "Gestor,Cliente")]   --> só users do tipo Gestor OU do tipo Cliente podem aceder
      
       [Authorize(Roles = "Gestor")]
       [Authorize(Roles = "Cliente")]          --> só users do tipo Gestor E do tipo Cliente podem aceder
      */
      public async Task<IActionResult> DesbloquearUtilizadores() {
         // Tarefas
         // 1. listar os Utilizadores bloqueados (email não validado / data bloqueio > data atual)
         // 2. listar os Criadores associados a esses Utilizadores

         // Tarefa 1.
         var listaIdUtilizadores = _userManager.Users
                                           .Where(u => !u.EmailConfirmed || u.LockoutEnd > DateTime.Now)
                                           .Select(u => u.Id);

         // Tarefa 2.
         var listaCriadores = await _db.Criadores.Where(c => listaIdUtilizadores.Contains(c.UserNameId))
                                                 .ToListAsync();

         // enviar a lista de criadores para a View
         return View(listaCriadores);
      }

      /// <summary>
      /// Após a listagem dos Utilizadores a desbloquear,
      /// processa esse desbloqueio
      /// </summary>
      /// <param name="listaUsersDesbloquear">lista dos ID dos utilizadores a desbloquear</param>
      /// <returns></returns>
      [HttpPost]
      [Authorize(Roles = "Gestor")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DesbloquearUtilizadores(string[] listaUsersDesbloquear) {

         /* tarefas:
         *  1. se listaUsersDesbloquear = vazio
         *        - nada se pode fazer
         *     caso contrário
         *        2. procurar pelo Utilizador cujo ID foi fornecido
         *        3. desbloquear esse utilizador
         *             3.1 - alterar a data do LockoutDate
         *             3.2 - validar o email
         */

         // Tarefa 1.
         if (listaUsersDesbloquear.Count() != 0) {
            // pq existem dados
            foreach (string userId in listaUsersDesbloquear) {
               try {
                  // Tarefa 2.
                  var user = await _userManager.FindByIdAsync(userId);
                  // Tarefa 3.1
                  await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddDays(-10));
                  // Tarefa 3.2
                  string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                  await _userManager.ConfirmEmailAsync(user, token);
               }
               catch (Exception) {
                  // enviar msg de erro ao utilizador
                  // devolver para uma view
               }
               // eventualmente, enviar um email a cada utilizador
               // a informar que a sua conta foi desbloqueada

            }
         }

         // eventualmente, gerar uma mensagem de sucesso para o utilizador

         // devolver à view
         return RedirectToAction("Index", "Home");
      }



      //// GET: Criadores/Create
      //public IActionResult Create() {
      //   return View();
      //}

      //// POST: Criadores/Create
      //// To protect from overposting attacks, enable the specific properties you want to bind to.
      //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      //[HttpPost]
      //[ValidateAntiForgeryToken]
      //public async Task<IActionResult> Create([Bind("Id,Nome,NomeComercial,Morada,CodPostal,Email,Telemovel")] Criadores criadores) {
      //   if (ModelState.IsValid) {
      //      _context.Add(criadores);
      //      await _context.SaveChangesAsync();
      //      return RedirectToAction(nameof(Index));
      //   }
      //   return View(criadores);
      //}

      // GET: Criadores/Edit/5
      public async Task<IActionResult> Edit(int? id) {
         if (id == null) {
            return NotFound();
         }

         var criadores = await _db.Criadores.FindAsync(id);
         if (criadores == null) {
            return NotFound();
         }
         return View(criadores);
      }

      // POST: Criadores/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NomeComercial,Morada,CodPostal,Email,Telemovel")] Criadores criadores) {
         if (id != criadores.Id) {
            return NotFound();
         }

         if (ModelState.IsValid) {
            try {
               _db.Update(criadores);
               await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
               if (!CriadoresExists(criadores.Id)) {
                  return NotFound();
               }
               else {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         return View(criadores);
      }

      // GET: Criadores/Delete/5
      public async Task<IActionResult> Delete(int? id) {
         if (id == null) {
            return NotFound();
         }

         var criadores = await _db.Criadores
             .FirstOrDefaultAsync(m => m.Id == id);
         if (criadores == null) {
            return NotFound();
         }

         return View(criadores);
      }

      // POST: Criadores/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id) {
         var criadores = await _db.Criadores.FindAsync(id);
         _db.Criadores.Remove(criadores);
         await _db.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool CriadoresExists(int id) {
         return _db.Criadores.Any(e => e.Id == id);
      }
   }
}
