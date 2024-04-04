﻿using CSharpVitamins;

namespace Core.Entities;

public class Author
{
    public ShortGuid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? PenName { get; set; }
    public string? ImageUrl { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}