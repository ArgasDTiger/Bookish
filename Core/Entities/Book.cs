using CSharpVitamins;

namespace Core.Entities;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int? Pages { get; set; }
    public decimal Price { get; set; }
    public DateOnly PublishDate { get; set; }
    public Publisher Publisher { get; set; }
    public ShortGuid PublisherId { get; set; }
    public ICollection<Genre> Genres { get; set; } = [];
    public ICollection<Author> Authors { get; set; } = [];
}