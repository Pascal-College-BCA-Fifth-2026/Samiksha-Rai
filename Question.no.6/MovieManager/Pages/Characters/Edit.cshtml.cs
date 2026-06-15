using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Characters;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Character Character { get; set; } = default!;

    public SelectList MovieList { get; set; } = default!;

    public SelectList ActorList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var character = await _context.Characters.FindAsync(id);

        if (character is null)
        {
            return NotFound();
        }

        Character = character;
        await PopulateDropdownsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropdownsAsync();
            return Page();
        }

        var character = await _context.Characters.FindAsync(id);

        if (character is null)
        {
            return NotFound();
        }

        character.MovieId = Character.MovieId;
        character.ActorId = Character.ActorId;
        character.CharacterName = Character.CharacterName;
        character.Pay = Character.Pay;
        character.ScreenTime = Character.ScreenTime;

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