using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    private readonly BooksContext _context;

    public BookRepository(BooksContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var spec = new BooksWithAuthorsAndGenresSpecification(id);

        return await GetEntityWithSpec(spec);
    }
}