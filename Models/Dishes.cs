#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    // denotes ID
    [Key]
    public int DishId {get; set;}
    [Required]
    [MinLength(2, ErrorMessage="Chef's name must be at least 2 characters")]
    public string ChefName {get; set;} 
    [Required]
    [MinLength(2, ErrorMessage="Dish name must be at least 2 characters")]
    public string DishName {get; set;}
    [Required]
    [Range(0, Int32.MaxValue)]
    public int Calories {get; set;}
    [Required]
    [Range(1, 6)]
    public int Tastiness {get; set;}
    [Required]
    [MinLength(5, ErrorMessage="Description must be at least 5 characters")]
    public string Description {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}