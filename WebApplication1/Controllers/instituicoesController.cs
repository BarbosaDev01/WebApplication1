using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class instituicoesController : Controller
    {
        private readonly WebApplication1Context _context;

        public instituicoesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: instituicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.instituicoes.ToListAsync());
        }

        // GET: instituicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.instituicoes
                .FirstOrDefaultAsync(m => m.instid == id);
            if (instituicoes == null)
            {
                return NotFound();
            }

            return View(instituicoes);
        }

        // GET: instituicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: instituicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("instid,instnome,instendereco")] instituicoes instituicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicoes);
        }

        // GET: instituicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.instituicoes.FindAsync(id);
            if (instituicoes == null)
            {
                return NotFound();
            }
            return View(instituicoes);
        }

        // POST: instituicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("instid,instnome,instendereco")] instituicoes instituicoes)
        {
            if (id != instituicoes.instid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!instituicoesExists(instituicoes.instid))
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
            return View(instituicoes);
        }

        // GET: instituicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.instituicoes
                .FirstOrDefaultAsync(m => m.instid == id);
            if (instituicoes == null)
            {
                return NotFound();
            }

            return View(instituicoes);
        }

        // POST: instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicoes = await _context.instituicoes.FindAsync(id);
            if (instituicoes != null)
            {
                _context.instituicoes.Remove(instituicoes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool instituicoesExists(int id)
        {
            return _context.instituicoes.Any(e => e.instid == id);
        }
    }
}
