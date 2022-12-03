﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using DataModel;
//using RazorPages.Data;

//namespace RazorPages.Controllers;

//public class ProductsController : Controller
//{
//    private readonly ApplicationDbContext _context;

//    public ProductsController(ApplicationDbContext context)
//    {
//        _context = context;
//    }
        
//    public async Task<IActionResult> Index()
//    {
//        var applicationDbContext = _context.Product.Include(x => x.Producer);
//        return View(await applicationDbContext.ToListAsync());
//    }

//    // GET: Products/Details/5
//    public async Task<IActionResult> Details(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var product = await _context.Product
//            .Include(p => p.Producer)
//            .FirstOrDefaultAsync(x => x.Id == id);

//        if (product == null)
//        {
//            return NotFound();
//        }

//        return View(product);
//    }

//    // GET: Products/Create
//    public IActionResult Create()
//    {
//        ViewData["IdOfProducer"] = new SelectList(_context.Producer, "Id", "Email");
//        return View();
//    }

//    // POST: Products/Create
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("Id,Name,Type,IdOfProducer,pH,Mineralization,PackingType,Volume,ImageData,AvailableAmount")] Product product)
//    {
//        if (ModelState.IsValid)
//        {
//            _context.Add(product);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        ViewData["IdOfProducer"] = new SelectList(_context.Producer, "Id", "Email", product.IdOfProducer);
//        return View(product);
//    }

//    // GET: Products/Edit/5
//    public async Task<IActionResult> Edit(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var product = await _context.Product.FindAsync(id);
//        if (product == null)
//        {
//            return NotFound();
//        }

//        ViewData["IdOfProducer"] = new SelectList(_context.Producer, "Id", "Email", product.IdOfProducer);
//        return View(product);
//    }

//    // POST: Products/Edit/5
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,IdOfProducer,pH,Mineralization,PackingType,Volume,ImageData,AvailableAmount")] Product product)
//    {
//        if (id != product.Id)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                _context.Update(product);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ProductExists(product.Id))
//                {
//                    return NotFound();
//                }

//                throw;
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        ViewData["IdOfProducer"] = new SelectList(_context.Producer, "Id", "Email", product.IdOfProducer);
//        return View(product);
//    }

//    // GET: Products/Delete/5
//    public async Task<IActionResult> Delete(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var product = await _context.Product
//            .Include(p => p.Producer)
//            .FirstOrDefaultAsync(x => x.Id == id);

//        if (product == null)
//        {
//            return NotFound();
//        }

//        return View(product);
//    }

//    // POST: Products/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int id)
//    {
//        var product = await _context.Product.FindAsync(id);
//        if (product != null)
//        {
//            _context.Product.Remove(product);
//        }
            
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }

//    private bool ProductExists(int id)
//    {
//        return _context.Product.Any(e => e.Id == id);
//    }
//}