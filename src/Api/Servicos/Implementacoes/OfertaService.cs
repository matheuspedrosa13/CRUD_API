using CrudOfertas.Api.Repositorios.Interfaces;
using CrudOfertas.Api.Servicos.Interfaces;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servico;
using CrudOfertas.Api.Servicos.DTOs;
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

    public void AdicionarOferta(OfertaDTOPost oferta, int valorID)
    {
        AdicionandoCoisasFixasEmOferta.AdicionadoPadraoOferta(oferta, _ofertaRepository, valorID);
        if (ValidarOferta.Validar(oferta))
        {
            OfertaDAO ofertaDAO = ConverterDTOemDAOPost.Converter(oferta);
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



}