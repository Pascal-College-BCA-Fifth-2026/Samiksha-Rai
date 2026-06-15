using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Actors;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Actor> Actors { get; set; } = [];

    public async Task OnGetAsync()
    {
        Actors = await _context.Actors
            .OrderBy(a => a.Name)
            .ToListAsync();
    }
}