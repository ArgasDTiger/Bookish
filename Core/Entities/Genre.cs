using CSharpVitamins;

namespace Core.Entities;

public class Genre
{
    public ShortGuid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}