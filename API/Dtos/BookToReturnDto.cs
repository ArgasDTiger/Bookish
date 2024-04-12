using Core.Entities;

namespace API.Dtos;

public class BookToReturnDto
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int? Pages { get; set; }
    public decimal Price { get; set; }
    public DateOnly PublishDate { get; set; }
    public string? Publisher { get; set; }
    public ICollection<string> Genres { get; set; } = new List<string>();
    public ICollection<string> Authors { get; set; } = new List<string>();
}