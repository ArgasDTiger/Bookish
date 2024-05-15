using Core.Entities;
using Core.Specifications.Params;

namespace Core.Specifications;

public class BooksWithAuthorsAndGenresSpecification : BaseSpecification<Book>
{
    // in some time the error will occur here, so you should implement GenreIds and AuthorIds as in BookWithFiltersForCountSpecification
    
    public BooksWithAuthorsAndGenresSpecification()
    {
        AddInclude(x => x.Genres);
        AddInclude(x => x.Authors);
        AddInclude(x => x.Publisher);
    }
    
    public BooksWithAuthorsAndGenresSpecification(BookSpecParams bookParams)
        : base(x =>
            (string.IsNullOrEmpty(bookParams.Search) || x.Title.ToLower().Contains(bookParams.Search.ToLower())) &&
            (!bookParams.PublisherId.HasValue || x.PublisherId == bookParams.PublisherId) &&
            (bookParams.AuthorIds == null || !bookParams.AuthorIds.Any() || bookParams.AuthorIds.Any(id => x.Authors.Select(a => a.Id).Contains(id))) &&
            (bookParams.GenreIds == null || !bookParams.GenreIds.Any() || bookParams.GenreIds.Any(id => x.Genres.Select(g => g.Id).Contains(id)))
        )

    {
        AddInclude(x => x.Genres);
        AddInclude(x => x.Authors);
        AddInclude(x => x.Publisher);
        // AddOrderBy(x => x.Title);
        ApplyPaging(bookParams.PageSize * (bookParams.PageIndex - 1), bookParams.PageSize);

        if (!string.IsNullOrEmpty(bookParams.Sort))
        {
            switch (bookParams.Sort)
            {
                case "titleAsc":
                    AddOrderBy(t => t.Title);
                    break;
                case "titleDesc":
                    AddOrderBy(t => t.Title);
                    break;
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Title);
                    break;
            }
        }
    }

    public BooksWithAuthorsAndGenresSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Genres);
        AddInclude(x => x.Authors);
        AddInclude(x => x.Publisher);
    }
}