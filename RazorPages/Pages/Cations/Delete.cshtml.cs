﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataModel;
using RazorPages.Data;

namespace RazorPages.Pages.Cations;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;

        Cation = new Cation();
    }

    [BindProperty]
    public Cation Cation { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cation = await _context.Cations.FirstOrDefaultAsync(x => x.Id == id);
        if (cation == null)
        {
            return NotFound();
        }
        
        Cation = cation;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cation = await _context.Cations.FindAsync(id);
        if (cation == null)
        {
            return RedirectToPage("./Index");
        }

        Cation = cation;
        _context.Cations.Remove(Cation);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}