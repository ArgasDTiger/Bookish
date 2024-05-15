using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(BooksContext context) : base(context)
    {
    }
}