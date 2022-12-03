using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataModel;
using RazorPages.Data;
using System.Globalization;

namespace RazorPages.Pages.Cations;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;

        Cation = new Cation();
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Cation Cation { get; set; }
        

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        var concentrationAsText = Request.Form["concentration"];


        //TODO usunac jak beda jezyki i odkomentowac to na dole
		var ci=new CultureInfo("pl-PL");

        //CultureInfo ci;

        //if(jezyk == polski) ci = new CultureInfo("pl-PL");
        //else ci = new CultureInfo("en-GB");

        double concentration;

	    concentration = double.Parse(concentrationAsText, ci);		

        Cation.Concentration = concentration;

        _context.Cations.Add(Cation);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}