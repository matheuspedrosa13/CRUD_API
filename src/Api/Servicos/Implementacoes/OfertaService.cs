using CrudOfertas.Api.Repositorios.Interfaces;
using CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servico;
using CrudOfertas.Api.Controllers.Requisicoes;
using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Servicos.Conversores;
namespace CrudOfertas.Api.Servicos.Implementacos;
public class OfertaService : IOfertaService
{
    private readonly IOfertaRepository _ofertaRepository;

    public OfertaService(IOfertaRepository ofertaRepository)
    {
        _ofertaRepository = ofertaRepository;
    }

    public List<OfertaDAO> ObterTodasOfertas()
    {
        return _ofertaRepository.ObterTodasOfertas();
    }

    public OfertaDAO ObterOfertaPorId(int id)
    {
        return _ofertaRepository.ObterOfertaPorId(id);
    }

    public void AdicionarOferta(OfertaDTOPost oferta)
    {
        AdicionandoCoisasFixasEmOferta.AdicionadoPadraoOferta(oferta);
        if (ValidarOferta.Validar(oferta))
        {
            OfertaDAO ofertaDAO = ConverterDTOemDAO.Converter(oferta);
            _ofertaRepository.AdicionarOferta(ofertaDAO);
        }
        else
        {
            throw new ArgumentException("Oferta inválida. Verifique os dados.");
        }
    }

    public void AtualizarOferta(OfertaDAO oferta)
    {
        // if (ValidarOferta.Validar(oferta))
        // {
        //     _ofertaRepository.AtualizarOferta(oferta);
        // }
        // else
        // {
        //     throw new ArgumentException("Oferta inválida. Verifique os dados.");
        // }
    }

    public void RemoverOferta(int id)
    {
        _ofertaRepository.RemoverOferta(id);
    }

    public List<OfertaDTOGet> ofertaVerificada(List<OfertaDAO> todasOfertasDAO, ParametrosBuscaOferta parametrosBuscaOferta){
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
            return todasOfertasDTO;
        }

        return todasOfertasDTO;
    }

}