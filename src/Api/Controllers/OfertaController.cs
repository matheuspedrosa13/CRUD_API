using Microsoft.AspNetCore.Mvc;
using CrudOfertas.Api.Infraestrutura;
using CrudOfertas.Api.Repositorios.DAOs;

namespace CrudOfertas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertaController : ControllerBase
    {


        [HttpGet("ofertas")]
        public ActionResult<IEnumerable<OfertaDAO>> GetOfertas()
        {
            var ofertas = OfertaDatabase.ObterOfertas();
            Console.WriteLine(ofertas);
            return Ok(ofertas);
        }
    }
}


        //OkResult: Representa uma resposta HTTP 200 (OK).
        //JsonResult: Permite retornar um objeto serializado como JSON.
        //ViewResult: Usado para retornar uma página HTML renderizada (geralmente uma View em MVC).
        //RedirectResult: Utilizado para redirecionar para outra URL.
        //NotFoundResult: Indica uma resposta HTTP 404 (não encontrado).
        //BadRequestResult: Indica uma resposta HTTP 400 (solicitação inválida).
        //UnauthorizedResult: Indica uma resposta HTTP 401 (não autorizado) e assim por diante.
        //IActionResult: Retorna o que vier para ele