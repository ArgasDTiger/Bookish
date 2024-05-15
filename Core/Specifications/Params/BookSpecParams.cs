namespace Core.Specifications.Params;

public class BookSpecParams : PageParams
{
    public int? PublisherId { get; set; }
    public ICollection<int>? AuthorIds { get; set; }
    public ICollection<int>? GenreIds { get; set; }
}