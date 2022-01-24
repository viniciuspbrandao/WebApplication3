#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class Cadastro2Controller : Controller
    {
        private readonly Context _context;

        public Cadastro2Controller(Context context)
        {
            _context = context;
        }

        // GET: Cadastro2
        public async Task<IActionResult> Index()
        {
            return View(await _context.cadastros.ToListAsync());
        }

        // GET: Cadastro2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro2 = await _context.cadastros
                .FirstOrDefaultAsync(m => m.Idade == id);
            if (cadastro2 == null)
            {
                return NotFound();
            }

            return View(cadastro2);
        }

        // GET: Cadastro2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idade,Nome,Cpf,Email,Telefone,Qual_serviço_você_procura,Qual_serviço_você_oferece")] Cadastro2 cadastro2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro2);
        }

        // GET: Cadastro2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro2 = await _context.cadastros.FindAsync(id);
            if (cadastro2 == null)
            {
                return NotFound();
            }
            return View(cadastro2);
        }

        // POST: Cadastro2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idade,Nome,Cpf,Email,Telefone,Qual_serviço_você_procura,Qual_serviço_você_oferece")] Cadastro2 cadastro2)
        {
            if (id != cadastro2.Idade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cadastro2Exists(cadastro2.Idade))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro2);
        }

        // GET: Cadastro2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro2 = await _context.cadastros
                .FirstOrDefaultAsync(m => m.Idade == id);
            if (cadastro2 == null)
            {
                return NotFound();
            }

            return View(cadastro2);
        }

        // POST: Cadastro2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro2 = await _context.cadastros.FindAsync(id);
            _context.cadastros.Remove(cadastro2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cadastro2Exists(int id)
        {
            return _context.cadastros.Any(e => e.Idade == id);
        }
    }
}
