using Microsoft.AspNetCore.Mvc;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Servicos;

namespace CrudOfertas.Api.Controllers.Requisicoes.Read;
public class RequisicoesDeLeitura
{
    public static ActionResult<List<OfertaDTOGet>> TodasAsOfertas(IOfertaService interfaceOfertas)
    {
        var ofertasDAO = interfaceOfertas.ObterTodasOfertas();
        var ofertasDTO = new List<OfertaDTOGet>();

        foreach (var ofertaDAO in ofertasDAO)
        {
            var ofertaDTO = ConverterDAOemDTO.Converter(ofertaDAO);
            ofertasDTO.Add(ofertaDTO);
        }

        return ofertasDTO;
    }
}