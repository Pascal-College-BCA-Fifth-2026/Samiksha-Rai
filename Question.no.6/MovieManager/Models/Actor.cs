using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManager.Models;

public class Actor
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    [MaxLength(100)]
    public string BirthCity { get; set; } = string.Empty;

    [MaxLength(100)]
    public string BirthCountry { get; set; } = string.Empty;

    public double HeightInches { get; set; }

    public string Biography { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Gender { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal NetWorth { get; set; }

    public ICollection<Character> Characters { get; set; } = new List<Character>();
}