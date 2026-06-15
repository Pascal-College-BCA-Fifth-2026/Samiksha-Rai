using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieManager.Models;

public class Character
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int ActorId { get; set; }

    [Required]
    [MaxLength(100)]
    public string CharacterName { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Pay { get; set; }

    public int ScreenTime { get; set; }

    [ValidateNever]
    public Movie Movie { get; set; } = null!;

    [ValidateNever]
    public Actor Actor { get; set; } = null!;
}