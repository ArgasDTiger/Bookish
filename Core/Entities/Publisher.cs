using CSharpVitamins;

namespace Core.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}