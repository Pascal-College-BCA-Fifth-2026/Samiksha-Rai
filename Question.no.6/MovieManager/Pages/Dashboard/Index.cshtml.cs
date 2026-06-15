using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;

namespace MovieManager.Pages.Dashboard;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<FlopMovieViewModel> FlopMovies { get; set; } = [];
    public List<HighestPaidActorViewModel> HighestPaidActors { get; set; } = [];

    public async Task OnGetAsync()
    {
        FlopMovies = await _context.Movies
            .AsNoTracking()
            .Where(m => m.Gross < m.Budget)
            .OrderByDescending(m => m.Budget - m.Gross)
            .Take(10)
            .Select(m => new FlopMovieViewModel
            {
                Title = m.Title,
                Budget = m.Budget,
                Gross = m.Gross,
                Loss = m.Budget - m.Gross
            })
            .ToListAsync();

        HighestPaidActors = await _context.Characters
            .AsNoTracking()
            .Include(c => c.Actor)
            .Include(c => c.Movie)
            .OrderByDescending(c => c.Pay)
            .Take(5)
            .Select(c => new HighestPaidActorViewModel
            {
                ActorName = c.Actor.Name,
                CharacterName = c.CharacterName,
                MovieTitle = c.Movie.Title,
                Pay = c.Pay
            })
            .ToListAsync();
    }
}

public class FlopMovieViewModel
{
    public string Title { get; set; } = string.Empty;
    public decimal Budget { get; set; }
    public decimal Gross { get; set; }
    public decimal Loss { get; set; }
}

public class HighestPaidActorViewModel
{
    public string ActorName { get; set; } = string.Empty;
    public string CharacterName { get; set; } = string.Empty;
    public string MovieTitle { get; set; } = string.Empty;
    public decimal Pay { get; set; }
}