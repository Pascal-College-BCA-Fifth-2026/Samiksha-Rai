using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Characters;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Character Character { get; set; } = default!;

    public SelectList MovieList { get; set; } = default!;

    public SelectList ActorList { get; set; } = default!;

    public async Task OnGetAsync()
    {
        await PopulateDropdownsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            foreach (var item in ModelState)
            {
                Console.WriteLine($"FIELD: {item.Key}");

                foreach (var error in item.Value.Errors)
                {
                    Console.WriteLine($"ERROR: {error.ErrorMessage}");
                }
            }

            await PopulateDropdownsAsync();
            return Page();
        }

        _context.Characters.Add(Character);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private async Task PopulateDropdownsAsync()
    {
        MovieList = new SelectList(
            await _context.Movies.OrderBy(m => m.Title).ToListAsync(),
            nameof(Movie.Id),
            nameof(Movie.Title));

        ActorList = new SelectList(
            await _context.Actors.OrderBy(a => a.Name).ToListAsync(),
            nameof(Actor.Id),
            nameof(Actor.Name));
    }
}