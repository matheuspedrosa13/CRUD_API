using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Servicos.Conversores;
using CrudOfertas.Api.Controllers.Requisicoes;
using CrudOfertas.Api.Excecoes;

namespace CrudOfertas.Api.Controllers;

[ApiController]
[Route("/ofertas")]
public class OfertaController : ControllerBase
{
    private readonly IOfertaService _ofertaService;

    public OfertaController(IOfertaService ofertaService)
    {
        _ofertaService = ofertaService;
    }


    [HttpGet]
    public ActionResult<List<OfertaDTOGet>> GetOfertas([FromQuery] ParametrosBuscaOferta parametrosBuscaOferta)
    {
        var todasOfertasDAO = _ofertaService.ObterTodasOfertas();
        List<OfertaDTOGet> listaDTOGet = _ofertaService.ofertaVerificada(todasOfertasDAO, parametrosBuscaOferta);
        if(listaDTOGet.Count == 0){
            return NotFound("Nenhuma oferta encontrada");
        }
        return listaDTOGet;
    }


    [HttpGet("/{id}")]
    public ActionResult<OfertaDTOGet> BuscarOfertaPorId(int id)
    {
        var ofertaDAO = _ofertaService.ObterOfertaPorId(id);

        if (ofertaDAO == null)
        {
            return NotFound();
        }

        var ofertaDTO = ConverterDAOemDTO.Converter(ofertaDAO);

        return Ok(ofertaDTO); 
    }


    [HttpPost]
    public ActionResult<string> AdicionarOferta([FromBody] OfertaDTOPost ofertaDTO)
    {
        try
        {
            var ofertas = _ofertaService.ObterTodasOfertas();
            int quantidadeDeOfertas = ofertas.Count;
            ofertaDTO.Id = quantidadeDeOfertas + 1;
            _ofertaService.AdicionarOferta(ofertaDTO);
            return "Oferta adicionada com sucesso";
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ErrosDeValidacaoException erro)
        {
            var options1 = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            return BadRequest(JsonSerializer.Serialize(erro.Erros, options1));
        }
    }

    [HttpPut("/{id}")]
    public IActionResult AtualizarOferta(int id, [FromBody] OfertaDTOPut ofertaDTO)
    {
        try
        {
            _ofertaService.AtualizarOferta(id, ofertaDTO);
            return Ok("Oferta atualizada com sucesso!");
        }
        catch (ErrosDeValidacaoException ex)
        {
            var response = new
            {
                Mensagem = "Erro de validação",
                Erros = ex.Erros
            };
            return BadRequest(response);
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro interno do servidor");
        }
    }




    [HttpPatch("/desativar/{id}")]
    public IActionResult DesativarOferta(int id)
    {
        try
        {
            _ofertaService.DesativarOferta(id);
            return Ok("Oferta desativada com sucesso!");
        }
        catch (ErrosDeValidacaoException ex)
        {
            var response = new
            {
                Mensagem = "Erro de validação",
                Erros = ex.Erros
            };
            return BadRequest(response);
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro interno do servidor");
        }
    }    
    
    [HttpPatch("/ativar/{id}")]
    public IActionResult AtivarOferta(int id)
    {
        try
        {
            _ofertaService.AtivarOferta(id);
            return Ok("Oferta ativada com sucesso!");
        }
        catch (ErrosDeValidacaoException ex)
        {
            var response = new
            {
                Mensagem = "Erro de validação",
                Erros = ex.Erros
            };
            return BadRequest(response);
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro interno do servidor");
        }
    }

}