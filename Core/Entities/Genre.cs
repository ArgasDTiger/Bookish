using CSharpVitamins;

namespace Core.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}