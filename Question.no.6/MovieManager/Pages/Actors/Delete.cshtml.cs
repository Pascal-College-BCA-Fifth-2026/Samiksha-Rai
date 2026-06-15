using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Actors;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

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
        var actor = await _context.Actors.FindAsync(id);

        if (actor is not null)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}