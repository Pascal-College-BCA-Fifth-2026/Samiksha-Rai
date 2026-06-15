using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManager.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string Rating { get; set; } = "";

    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Gross { get; set; }

    public DateTime ReleaseDate { get; set; }

    [MaxLength(50)]
    public string Genre { get; set; } = string.Empty;

    public int Runtime { get; set; }

    public string Summary { get; set; } = string.Empty;

    public ICollection<Character> Characters { get; set; } = new List<Character>();
}