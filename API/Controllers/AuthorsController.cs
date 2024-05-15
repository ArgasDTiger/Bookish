using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthorsController : BaseApiController
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAuthors([FromQuery] AuthorSpecParams authorParams)
    {
        var spec = new AuthorsWithBooksSpecification(authorParams);

        var countSpec = new AuthorWithFiltersForCountSpecification(authorParams);

        var authors = await _authorRepository.GetListAsync(spec);

        var totalItems = await _authorRepository.CountAsync(countSpec);

        var data = _mapper
            .Map<IReadOnlyList<Author>, IReadOnlyList<AuthorDto>>(authors);
        
        return Ok(new Pagination<AuthorDto>(authorParams.PageIndex, authorParams.PageSize, totalItems, data));
    }
    
    [HttpGet("fullnames")]
    public async Task<ActionResult> GetAuthorsFullNames()
    {
        var spec = new AuthorsWithSortAscendingSpecification();

        var authors = await _authorRepository.GetListAsync(spec);

        var data = _mapper
            .Map<IReadOnlyList<Author>, IReadOnlyList<AuthorFullNameDto>>(authors);
        
        return Ok(data);
    }
    
}