using Core.Entities;
using Core.Specifications.Params;

namespace Core.Specifications;

public class GenresWithSortSpecification : BaseSpecification<Genre>
{
    public GenresWithSortSpecification(GenreSpecParams genreParams)
    {
        if (genreParams is { Sort: "desc" })
        {
            AddOrderByDescending(x => x.Name);
        }
        else
        {
            AddOrderBy(x => x.Name);
        }
    }

    
}