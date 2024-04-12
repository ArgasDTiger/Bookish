using Core.Entities;

namespace Core.Specifications;

public class BooksWithAuthorsAndGenresSpecification : BaseSpecification<Book>
{
    public BooksWithAuthorsAndGenresSpecification()
    {
        AddInclude(x => x.Genres);
        AddInclude(x => x.Authors);
        AddInclude(x => x.Publisher);
    }
    
    public BooksWithAuthorsAndGenresSpecification(BookSpecParams bookParams)
        : base(x =>
            (string.IsNullOrEmpty(bookParams.Search) || x.Title.ToLower().Contains(bookParams.Search)) &&
            (!bookParams.PublisherId.HasValue || x.PublisherId == bookParams.PublisherId) &&
            (bookParams.AuthorId == null || !bookParams.AuthorId.Any() || bookParams.AuthorId.Any(id => x.Authors.Select(a => a.Id).Contains(id))) &&
            (bookParams.GenreId == null || !bookParams.GenreId.Any() || bookParams.GenreId.Any(id => x.Genres.Select(g => g.Id).Contains(id)))
        )
    {
        AddInclude(x => x.Genres!);
        AddInclude(x => x.Authors!);
        AddInclude(x => x.Publisher);
        AddOrderBy(x => x.Title!);
        ApplyPaging(bookParams.PageSize * (bookParams.PageIndex - 1), bookParams.PageSize);

        if (!string.IsNullOrEmpty(bookParams.Sort))
        {
            switch (bookParams.Sort)
            {
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