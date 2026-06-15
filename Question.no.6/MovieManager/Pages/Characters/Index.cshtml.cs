using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Characters;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Character> Characters { get; set; } = [];

    public async Task OnGetAsync()
    {
        Characters = await _context.Characters
            .Include(c => c.Movie)
            .Include(c => c.Actor)
            .OrderBy(c => c.CharacterName)
            .ToListAsync();
    }
}