using CSharpVitamins;

namespace Core.Entities;

public class AuthorBook
{
    public ShortGuid AuthorId { get; set; }
    public ShortGuid BookId { get; set; }
    public Author Author { get; set; }
    public Book Book { get; set; }
}