using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Characters;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
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
}