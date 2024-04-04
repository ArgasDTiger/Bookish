using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{

    public AuthorRepository(BooksContext context) : base(context)
    {
    }
    
}