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
        var nome = parametrosBuscaOferta.nome;
        var liquidez = parametrosBuscaOferta.liquidez;
        var aprovada = parametrosBuscaOferta.aprovada;
        Console.WriteLine(liquidez);
        if(nome != ""){
            Console.WriteLine(nome);
            var ofertasDAONome = _ofertaService.ObterTodasOfertas()
            .Where(o => o.NomeTitulo!.ToLower().Contains(nome.ToLower()))
            .ToList();

            var ofertasDTONome = ofertasDAONome.Select(ofertasDAO => ConverterDAOemDTO.Converter(ofertasDAO)).ToList();

            if (ofertasDTONome.Count() == 0)
            {
                return NotFound("Nenhuma oferta encontrada com o nome especificado.");
            }

            return ofertasDTONome;

        }
        
        if (liquidez == true) {

            var ofertasDAOLiquidez = _ofertaService.ObterTodasOfertas()
                .Where(o => o.Liquidez == true)
                .ToList();

            var ofertasDTOLiquidez = ofertasDAOLiquidez.Select(ofertaDAO => ConverterDAOemDTO.Converter(ofertaDAO)).ToList();

            if (ofertasDTOLiquidez.Count() == 0)
            {
                return NotFound("Nenhuma oferta encontrada com essa liquidez.");
            }

            return ofertasDTOLiquidez;  
        }
        
        if (aprovada == true) {

            var ofertasDAOAprovada = _ofertaService.ObterTodasOfertas()
                .Where(o => o.Aprovada == true)
                .ToList();

            var ofertasDTOAprovada = ofertasDAOAprovada.Select(ofertaDAO => ConverterDAOemDTO.Converter(ofertaDAO)).ToList();

            if (ofertasDTOAprovada.Count() == 0)
            {
                return NotFound("Nenhuma oferta encontrada aprovada.");
            }

            return ofertasDTOAprovada;  
        }
        // if (liquidez == false) {
        //     Console.WriteLine("entrou aqui 2r");

        //     var ofertasDAOLiquidez = _ofertaService.ObterTodasOfertas()
        //         .Where(o => o.Liquidez == false)
        //         .ToList();

        //     var ofertasDTOLiquidez = ofertasDAOLiquidez.Select(ofertaDAO => ConverterDAOemDTO.Converter(ofertaDAO)).ToList();

        //     if (ofertasDTOLiquidez.Count() == 0)
        //     {
        //         return NotFound("Nenhuma oferta encontrada com essa liquidez.");
        //     }

        //     return ofertasDTOLiquidez;  
        // }

        if(nome != "" && liquidez == true){
            var ofertasDAOLiquidezENome = _ofertaService.ObterTodasOfertas()
            .Where(o => o.Liquidez == true && o.NomeTitulo != "" && o.NomeTitulo!.ToLower().Contains(nome.ToLower()))
            .ToList();

            var ofertasDTOLiquidezENome = ofertasDAOLiquidezENome.Select(ofertaDAO => ConverterDAOemDTO.Converter(ofertaDAO)).ToList();

            if (ofertasDTOLiquidezENome.Count() == 0)
            {
                return NotFound("Nenhuma oferta encontrada com a liquidez e nome especificados.");
            }

            return ofertasDTOLiquidezENome;
        }

        
        if(nome != "" && liquidez == false){
            var ofertasDAOLiquidezENome = _ofertaService.ObterTodasOfertas()
            .Where(o => o.Liquidez == false && o.NomeTitulo != "" && o.NomeTitulo!.ToLower().Contains(nome.ToLower()))
            .ToList();

            var ofertasDTOLiquidezENome = ofertasDAOLiquidezENome.Select(ofertaDAO => ConverterDAOemDTO.Converter(ofertaDAO)).ToList();

            if (ofertasDTOLiquidezENome.Count() == 0)
            {
                return NotFound("Nenhuma oferta encontrada com a liquidez e nome especificados.");
            }

            return ofertasDTOLiquidezENome;
        }

        var ofertasDAO = _ofertaService.ObterTodasOfertas();
        var ofertasDTO = new List<OfertaDTOGet>();

        foreach (var ofertaDAO in ofertasDAO)
        {
            var ofertaDTO = ConverterDAOemDTO.Converter(ofertaDAO);
            ofertasDTO.Add(ofertaDTO);
        }

        return ofertasDTO;
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