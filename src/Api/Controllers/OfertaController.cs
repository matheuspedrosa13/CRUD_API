using Microsoft.AspNetCore.Mvc;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Servicos;
using CrudOfertas.Api.Controllers.Requisicoes;

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

        if (!string.IsNullOrWhiteSpace(parametrosBuscaOferta.nome))
        {
            todasOfertasDAO = todasOfertasDAO
                .Where(o => o.NomeTitulo != null && o.NomeTitulo.ToLower().Contains(parametrosBuscaOferta.nome.ToLower()))
                .ToList();
        }

        if (parametrosBuscaOferta.liquidez.HasValue)
        {
            todasOfertasDAO = todasOfertasDAO
                .Where(o => o.Liquidez == parametrosBuscaOferta.liquidez.Value)
                .ToList();
        }

        if (parametrosBuscaOferta.aprovada.HasValue)
        {
            todasOfertasDAO = todasOfertasDAO
                .Where(o => o.Aprovada == parametrosBuscaOferta.aprovada.Value)
                .ToList();
        }

        var todasOfertasDTO = todasOfertasDAO.Select(ofertaDAO => ConverterDAOemDTO.Converter(ofertaDAO)).ToList();

        if (todasOfertasDTO.Count == 0)
        {
            return NotFound("Nenhuma oferta encontrada.");
        }

        return todasOfertasDTO;
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
    }


    [HttpPut("/{id}")]
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

    [HttpDelete("/{id}")]
    public ActionResult DesaprovarOferta(int id)
    {
        _ofertaService.RemoverOferta(id);
        return Ok("Funfou"); // Retorna HTTP 204 (Sem conteúdo) se a remoção for bem-sucedida.
    }
}