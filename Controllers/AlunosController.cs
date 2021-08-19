using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aec_mvc_entity_framework.Models;
using aec_mvc_entity_framework.Servicos;

namespace aec_mvc_entity_framework.Controllers
{
    public class AlunosController : Controller
    {
        private readonly DbContexto _context;

        public AlunosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programadores.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programador = await _context.Programadores
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (programador == null)
            {
                return NotFound();
            }

            return View(programador);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,Tel")] Programador programador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programador);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programador = await _context.Programadores.FindAsync(id);
            if (programador == null)
            {
                return NotFound();
            }
            return View(programador);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nome,Tel")] Programador programador)
        {
            if (id != programador.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramadorExists(programador.Codigo))
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
            return View(programador);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programador = await _context.Programadores
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (programador == null)
            {
                return NotFound();
            }

            return View(programador);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programador = await _context.Programadores.FindAsync(id);
            _context.Programadores.Remove(programador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramadorExists(int id)
        {
            return _context.Programadores.Any(e => e.Codigo == id);
        }
    }
}
