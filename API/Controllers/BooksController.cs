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
    public async Task<ActionResult<BookToReturnDto>> GetBooks([FromQuery] BookSpecParams bookSpecParams)
    {
        var spec = new BooksWithAuthorsAndGenresSpecification();
        
        var books = await _bookRepository.GetListAsync(spec);
        
        var data = _mapper
            .Map<List<Book>, List<BookToReturnDto>>(books);
        return Ok(data);
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