using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class BasketItemDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least one")]
    public int Quantity { get; set; }
    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }
    [Required]
    public string Publisher { get; set; }
    [Required]
    public ICollection<string> Genres { get; set; } = [];
    [Required]
    public ICollection<string> Authors { get; set; } = [];
}