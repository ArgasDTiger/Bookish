using Core.Entities;
using Core.Specifications.Params;

namespace Core.Specifications;

public class AuthorsWithBooksSpecification : BaseSpecification<Author>
{
    public AuthorsWithBooksSpecification()
    {
        AddInclude(x => x.Books);
    }

    public AuthorsWithBooksSpecification(AuthorSpecParams authorParams)
        : base(x =>
            (string.IsNullOrEmpty(authorParams.Search) || x.Name.ToLower().Contains(authorParams.Search)) &&
            (authorParams.BookIds == null || !authorParams.BookIds.Any() || authorParams.BookIds.Any(id => x.Books.Select(b => b.Id).Contains(id))))
    {
        
    }
}