using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthorController : BaseApiController
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAuthors()
    {
        return Ok(await _authorRepository.GetListOfAllAsync());
    }
    
}