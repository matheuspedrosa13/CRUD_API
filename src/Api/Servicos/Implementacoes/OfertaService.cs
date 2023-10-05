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
        
    }

    public void RemoverOferta(int id)
    {
        _ofertaRepository.RemoverOferta(id);
    }

    public List<OfertaDTOGet> ofertaVerificada(List<OfertaDAO> todasOfertasDAO, ParametrosBuscaOferta parametrosBuscaOferta){
        if (!string.IsNullOrWhiteSpace(parametrosBuscaOferta.Nome))
        {
            todasOfertasDAO = todasOfertasDAO
                .Where(o => o.NomeTitulo != null && o.NomeTitulo.ToLower().Contains(parametrosBuscaOferta.Nome.ToLower()))
                .ToList();
        }

        if (parametrosBuscaOferta.Liquidez.HasValue)
        {
            todasOfertasDAO = todasOfertasDAO
                .Where(o => o.Liquidez == parametrosBuscaOferta.Liquidez!.Value)
                .ToList();
        }

        if (parametrosBuscaOferta.Aprovada.HasValue)
        {
            todasOfertasDAO = todasOfertasDAO
                .Where(o => o.Aprovada == parametrosBuscaOferta.Aprovada.Value)
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