using Microsoft.EntityFrameworkCore;
using MovieManager.Models;

namespace MovieManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Character> Characters => Set<Character>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Movie)
            .WithMany(m => m.Characters)
            .HasForeignKey(c => c.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Actor)
            .WithMany(a => a.Characters)
            .HasForeignKey(c => c.ActorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}