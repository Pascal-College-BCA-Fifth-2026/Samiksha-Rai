using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Movies;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Movie> Movies { get; set; } = [];

    public async Task OnGetAsync()
    {
        Movies = await _context.Movies
            .OrderBy(m => m.Title)
            .ToListAsync();
    }
}