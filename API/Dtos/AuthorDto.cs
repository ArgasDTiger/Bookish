namespace API.Dtos;

public class AuthorDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? PenName { get; set; }
    public string? ImageUrl { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public ICollection<string> Books { get; set; } = new List<string>();
}