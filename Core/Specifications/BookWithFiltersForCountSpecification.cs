using Core.Entities;
using Core.Specifications.Params;

namespace Core.Specifications;

public class BookWithFiltersForCountSpecification : BaseSpecification<Book>
{
    public BookWithFiltersForCountSpecification(BookSpecParams bookParams)
        : base(x =>
            (string.IsNullOrEmpty(bookParams.Search) || x.Title.ToLower().Contains(bookParams.Search.ToLower())) &&
            (bookParams.AuthorIds == null || !bookParams.AuthorIds.Any() || x.Authors.Select(g => g.Id).Any(id => bookParams.AuthorIds.Contains(id))) &&
            (bookParams.GenreIds == null || !bookParams.GenreIds.Any() || x.Genres.Select(g => g.Id).Any(id => bookParams.GenreIds.Contains(id))) &&
            (!bookParams.PublisherId.HasValue || x.PublisherId == bookParams.PublisherId)
        )
    {
    
    }

}