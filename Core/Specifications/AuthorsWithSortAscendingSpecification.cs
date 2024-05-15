using Core.Entities;

namespace Core.Specifications;

public class AuthorsWithSortAscendingSpecification : BaseSpecification<Author>
{
    public AuthorsWithSortAscendingSpecification()
    {
        AddOrderBy(x => x.Name);   
    }
}