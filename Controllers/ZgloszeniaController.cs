using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;

public class ZgloszeniaController : Controller
{
    private readonly AplikacjaContext _context;

    public ZgloszeniaController(AplikacjaContext context)
    {
        _context = context;
    }

    public IActionResult Home()
    {
        return RedirectToAction("Index", "Zgloszenia");
    }

    public async Task<IActionResult> Index()
    {
        var listaZgloszen = await _context.Zgloszenia.Include(z => z.Komentarze).ToListAsync();
        return View(listaZgloszen);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Zgloszenie zgloszenie)
    {
        if (ModelState.IsValid)
        {
            zgloszenie.DataZgloszenia = DateTime.Now;
            _context.Zgloszenia.Add(zgloszenie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(zgloszenie);
    }

    public async Task<IActionResult> Details(int id)
    {
        var zgloszenie = await _context.Zgloszenia.Include(z => z.Komentarze).ThenInclude(k => k.Uzytkownik).FirstOrDefaultAsync(z => z.Id == id);
        if (zgloszenie == null)
        {
            return NotFound();
        }
        return View(zgloszenie);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var zgloszenie = await _context.Zgloszenia.FindAsync(id);
        if (zgloszenie == null)
        {
            return NotFound();
        }
        return View(zgloszenie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Zgloszenie zgloszenie)
    {
        if (id != zgloszenie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(zgloszenie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZgloszenieExists(zgloszenie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(zgloszenie);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var zgloszenie = await _context.Zgloszenia.FindAsync(id);
        if (zgloszenie == null)
        {
            return NotFound();
        }

        _context.Zgloszenia.Remove(zgloszenie);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    private bool ZgloszenieExists(int id)
    {
        return _context.Zgloszenia.Any(e => e.Id == id);
    }
}
