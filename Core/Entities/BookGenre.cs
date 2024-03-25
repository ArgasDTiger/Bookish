using CSharpVitamins;

namespace Core.Entities;

public class BookGenre
{
    public ShortGuid BookId { get; set; }
    public ShortGuid GenreId { get; set; }
    public Book Book { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
}