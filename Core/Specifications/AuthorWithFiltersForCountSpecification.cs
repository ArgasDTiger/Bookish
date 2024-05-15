using Core.Entities;
using Core.Specifications.Params;

namespace Core.Specifications;

public class AuthorWithFiltersForCountSpecification : BaseSpecification<Author>
{
    public AuthorWithFiltersForCountSpecification(AuthorSpecParams authorParams)
        : base(x =>
            (string.IsNullOrEmpty(authorParams.Search) || x.Name.ToLower().Contains(authorParams.Search)) &&
            (authorParams.BookIds == null || !authorParams.BookIds.Any() || authorParams.BookIds.Any(id => x.Books.Select(b => b.Id).Contains(id))))
    {
        
    }
}