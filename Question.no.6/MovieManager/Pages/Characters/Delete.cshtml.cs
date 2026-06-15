using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Characters;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    public Character Character { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var character = await _context.Characters
            .Include(c => c.Movie)
            .Include(c => c.Actor)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character is null)
        {
            return NotFound();
        }

        Character = character;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var character = await _context.Characters.FindAsync(id);

        if (character is not null)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}