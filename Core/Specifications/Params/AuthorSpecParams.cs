namespace Core.Specifications.Params;

public class AuthorSpecParams : PageParams
{
    public ICollection<int>? BookIds { get; set; }
}