using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BookController : BaseApiController
{
    [HttpGet]
    public ActionResult GetHello()
    {
        return Ok("that's nice");
    }

}