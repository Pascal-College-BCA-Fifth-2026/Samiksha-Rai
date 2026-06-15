using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Actors;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Actor Actor { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var actor = await _context.Actors.FindAsync(id);

        if (actor is null)
        {
            return NotFound();
        }

        Actor = actor;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var actor = await _context.Actors.FindAsync(id);

        if (actor is null)
        {
            return NotFound();
        }

        actor.Name = Actor.Name;
        actor.DateOfBirth = Actor.DateOfBirth;
        actor.BirthCity = Actor.BirthCity;
        actor.BirthCountry = Actor.BirthCountry;
        actor.HeightInches = Actor.HeightInches;
        actor.Biography = Actor.Biography;
        actor.Gender = Actor.Gender;
        actor.NetWorth = Actor.NetWorth;

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}