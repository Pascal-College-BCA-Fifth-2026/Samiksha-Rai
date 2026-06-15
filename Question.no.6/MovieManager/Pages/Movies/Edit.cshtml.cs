using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Movies;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Movie Movie { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie is null)
        {
            return NotFound();
        }

        Movie = movie;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var movie = await _context.Movies.FindAsync(id);

        if (movie is null)
        {
            return NotFound();
        }

        movie.Title = Movie.Title;
        movie.Genre = Movie.Genre;
        movie.Rating = Movie.Rating;
        movie.ReleaseDate = Movie.ReleaseDate;
        movie.Runtime = Movie.Runtime;
        movie.Budget = Movie.Budget;
        movie.Gross = Movie.Gross;
        movie.Summary = Movie.Summary;

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}