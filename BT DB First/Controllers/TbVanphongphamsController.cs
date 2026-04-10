using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BT_DB_First.Models;

namespace BT_DB_First.Controllers
{
    public class TbVanphongphamsController : Controller
    {
        private readonly QlVanphongphamContext _context;

        public TbVanphongphamsController(QlVanphongphamContext context)
        {
            _context = context;
        }

        // GET: TbVanphongphams
        public async Task<IActionResult> Index()
        {
            var qlVanphongphamContext = _context.TbVanphongphams.Include(t => t.MaloaiNavigation);
            return View(await qlVanphongphamContext.ToListAsync());
        }

        // GET: TbVanphongphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVanphongpham = await _context.TbVanphongphams
                .Include(t => t.MaloaiNavigation)
                .FirstOrDefaultAsync(m => m.Mavanphongpham == id);
            if (tbVanphongpham == null)
            {
                return NotFound();
            }

            return View(tbVanphongpham);
        }

        // GET: TbVanphongphams/Create
        public IActionResult Create()
        {
            ViewData["Maloai"] = new SelectList(_context.TbDanhmucvanphongphams, "Maloai", "Maloai");
            return View();
        }

        // POST: TbVanphongphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mavanphongpham,Tenvanphongpham,Mota,Maloai")] TbVanphongpham tbVanphongpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbVanphongpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maloai"] = new SelectList(_context.TbDanhmucvanphongphams, "Maloai", "Maloai", tbVanphongpham.Maloai);
            return View(tbVanphongpham);
        }

        // GET: TbVanphongphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVanphongpham = await _context.TbVanphongphams.FindAsync(id);
            if (tbVanphongpham == null)
            {
                return NotFound();
            }
            ViewData["Maloai"] = new SelectList(_context.TbDanhmucvanphongphams, "Maloai", "Maloai", tbVanphongpham.Maloai);
            return View(tbVanphongpham);
        }

        // POST: TbVanphongphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mavanphongpham,Tenvanphongpham,Mota,Maloai")] TbVanphongpham tbVanphongpham)
        {
            if (id != tbVanphongpham.Mavanphongpham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbVanphongpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbVanphongphamExists(tbVanphongpham.Mavanphongpham))
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
            ViewData["Maloai"] = new SelectList(_context.TbDanhmucvanphongphams, "Maloai", "Maloai", tbVanphongpham.Maloai);
            return View(tbVanphongpham);
        }

        // GET: TbVanphongphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVanphongpham = await _context.TbVanphongphams
                .Include(t => t.MaloaiNavigation)
                .FirstOrDefaultAsync(m => m.Mavanphongpham == id);
            if (tbVanphongpham == null)
            {
                return NotFound();
            }

            return View(tbVanphongpham);
        }

        // POST: TbVanphongphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbVanphongpham = await _context.TbVanphongphams.FindAsync(id);
            if (tbVanphongpham != null)
            {
                _context.TbVanphongphams.Remove(tbVanphongpham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbVanphongphamExists(int id)
        {
            return _context.TbVanphongphams.Any(e => e.Mavanphongpham == id);
        }
    }
}
