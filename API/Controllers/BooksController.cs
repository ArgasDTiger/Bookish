using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BooksController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public BooksController(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<BookToReturnDto>> GetBooks([FromQuery] BookSpecParams bookParams)
    {
        var spec = new BooksWithAuthorsAndGenresSpecification(bookParams);

        var countSpec = new BookWithFiltersForCountSpecification(bookParams);

        var totalItems = await _bookRepository.CountAsync(countSpec);

        var books = await _bookRepository.GetListAsync(spec);
        
        var data = _mapper
            .Map<IReadOnlyList<Book>, IReadOnlyList<BookToReturnDto>>(books);
        return Ok(new Pagination<BookToReturnDto>(bookParams.PageIndex, bookParams.PageSize, totalItems, data));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookToReturnDto>> GetBook(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        
        var data = _mapper
            .Map<Book, BookToReturnDto>(book);
        return Ok(data);
    }

}