
using Microsoft.AspNetCore.Mvc;

namespace CrudOfertas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfertaController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Ok";
    }
}