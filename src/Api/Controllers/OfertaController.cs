using Microsoft.AspNetCore.Mvc;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Servicos;

namespace CrudOfertas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfertaController : ControllerBase
{
    private readonly IOfertaService _ofertaService;

    public OfertaController(IOfertaService ofertaService)
    {
        _ofertaService = ofertaService;
    }


    [HttpGet("ofertas")]
    public ActionResult<List<OfertaDTO>> GetOfertas()
    {
        var ofertasDAO = _ofertaService.ObterTodasOfertas();
        var ofertasDTO = new List<OfertaDTO>();

        foreach (var ofertaDAO in ofertasDAO)
        {
            var ofertaDTO = ConverterDAOemDTO.Converter(ofertaDAO);
            ofertasDTO.Add(ofertaDTO);
        }

        return ofertasDTO;
    }
    
    [HttpGet("ofertas/{id}")]
    public ActionResult<OfertaDTO> GetOfertaPorId(int id)
    {
        var ofertaDAO = _ofertaService.ObterOfertaPorId(id);

        if (ofertaDAO == null)
        {
            return NotFound();
        }

        var ofertaDTO = ConverterDAOemDTO.Converter(ofertaDAO);

        return Ok(ofertaDTO); 
    }

    [HttpPost("ofertas")]
    public ActionResult<string> AdicionarOferta(
        decimal PorcentagemEmissao,
        decimal PorcentagemDistribuicao,
        decimal TaxaEmissao,
        decimal TaxaDistribuicao,
        decimal PrecoUnitario,
        int Estoque,
        DateTime HorarioInicioNegociacao,
        DateTime HorarioFimNegociacao,
        bool Liquidez,
        string Indexador,
        string NomeEmissor,
        string NomeTitulo,
        string Risco,
        bool GarantidoPeloFGC,
        string Descricao,
        bool Aprovada
    )
    {
        try
        {
            var oferta = new OfertaDAO
            {
                PorcentagemEmissao = PorcentagemEmissao,
                PorcentagemDistribuicao = PorcentagemDistribuicao,
                TaxaEmissao = TaxaEmissao,
                TaxaDistribuicao = TaxaDistribuicao,
                PrecoUnitario = PrecoUnitario,
                Estoque = Estoque,
                HorarioInicioNegociacao = HorarioInicioNegociacao,
                HorarioFimNegociacao = HorarioFimNegociacao,
                Liquidez = Liquidez,
                Indexador = Indexador,
                NomeEmissor = NomeEmissor,
                NomeTitulo = NomeTitulo,
                Risco = Risco,
                GarantidoPeloFGC = GarantidoPeloFGC,
                Descricao = Descricao,
                Aprovada = Aprovada
            };
            List<OfertaDTO> ofertas = GetOfertas().Value!;
            int quantidadeDeOfertas = ofertas.Count;
            _ofertaService.AdicionarOferta(oferta, quantidadeDeOfertas);
            
            return "Oferta adicionada com sucesso";
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("ofertas/{id}")]
    public ActionResult AtualizarOferta(int id, OfertaDAO oferta)
    {
        oferta.Id = id; // Define o ID da oferta com base no parâmetro da rota.
        try
        {
            _ofertaService.AtualizarOferta(oferta);
            return NoContent(); // Retorna HTTP 204 (Sem conteúdo) se a atualização for bem-sucedida.
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message); // Retorna HTTP 400 com a mensagem de erro se a oferta for inválida.
        }
    }

    [HttpDelete("ofertas/{id}")]
    public ActionResult RemoverOferta(int id)
    {
        _ofertaService.RemoverOferta(id);
        return Ok("Funfou"); // Retorna HTTP 204 (Sem conteúdo) se a remoção for bem-sucedida.
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