using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GenresController : BaseApiController
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GenresController(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetGenres([FromQuery] GenreSpecParams genreParams)
    {
        var spec = new GenresWithSortSpecification(genreParams);

        var genres = await _genreRepository.GetListAsync(spec);
        
        var data = _mapper
            .Map<IReadOnlyList<Genre>, IReadOnlyList<GenreDto>>(genres);
        return Ok(data);
    }
    
}